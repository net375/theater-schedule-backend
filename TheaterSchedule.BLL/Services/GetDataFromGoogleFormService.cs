using HtmlAgilityPack;
using TheaterSchedule.BLL.Classes;
using System.Net;
using TheaterSchedule.BLL.Interfaces;
namespace TheaterSchedule.BLL.Services
{
    public class GetDataFromGoogleFormService:IGetDataFromGoogleFormService
    {
        private string rootUrl;

        public static string GetUrl(string address)
        {
            WebClient webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.Accept] = "text/html, */*";
            webClient.Headers[HttpRequestHeader.AcceptLanguage] = "ru-RU";
            webClient.Headers[HttpRequestHeader.UserAgent] =
                "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)";
            webClient.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded,  charset=utf-8";
            return webClient.DownloadString(address);
        }

        public Form GetDataFromServer(string rootUrl)
        {
            this.rootUrl = rootUrl.Replace("viewform", "formResponse?");

            HtmlDocument htmlSnippet = new HtmlDocument();
            string result;

            result = GetUrl(rootUrl);
            htmlSnippet.LoadHtml(result);
            HtmlNodeCollection nodes =
                htmlSnippet.DocumentNode.SelectNodes(
                    @"//div[@class='freebirdFormviewerViewNumberedItemContainer']");

            Form forms = new Form();
            foreach (HtmlNode node in nodes)
            {
                string title = node
                    .SelectSingleNode(
                        @".//div[@class='freebirdFormviewerViewItemsItemItemTitle exportItemTitle freebirdCustomFont']")
                    .InnerText;

                var multiple_input =
                    node.SelectNodes(
                        ".//div[@class='freebirdFormviewerViewItemsCheckboxOptionContainer']");

                var single_input =
                    node.SelectSingleNode(
                        ".//input");

                var radio_input =
                    node.SelectNodes(
                        @".//div[@class='freebirdFormviewerViewItemsRadioOptionContainer']");
                if (multiple_input != null)
                {
                    Multiple_Form record = new Multiple_Form();
                    record.title = title;
                    record.entry = node.SelectSingleNode(@".//input").Attributes["name"].Value.Replace("_sentinel", "");
                    foreach (HtmlNode node2 in multiple_input)
                    {
                        string choise = node2.SelectSingleNode(@".//span").InnerHtml;
                        record.choises.Add(choise);
                    }

                    forms.Multiple.Add(record);
                }
                else if (radio_input != null)
                {
                    Radio_Form record = new Radio_Form();
                    record.title = title;
                    record.entry = node.SelectSingleNode(@".//input").Attributes["name"].Value;
                    foreach (HtmlNode node3 in radio_input)
                    {
                        string choise = node3.SelectSingleNode(@".//span").InnerHtml;
                        record.choises.Add(choise);
                    }

                    forms.Radio.Add(record);
                }
                else if (single_input != null)
                {
                    Single_Form record = new Single_Form();
                    record.title = title;
                    record.entry = single_input.Attributes["name"].Value;
                    forms.Single.Add(record);
                }
            }
            return forms;
        }
    }
}
