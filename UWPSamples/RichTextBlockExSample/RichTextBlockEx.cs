using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using Windows.ApplicationModel.Email;
using Windows.Foundation.Metadata;
using Windows.System;
using Windows.UI;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Media;

namespace RichTextBlockExSample
{
    public enum RichTextType
    {
        Mention,
        Email,
        PhoneNumber,
        Webite,
        HtmlTag
    }

    public class MatchResult
    {
        public Match Match { get; set; }

        public string Path { get; set; }

        public RichTextType RichTextType { get; set; }
    }

    public class RichTextBlockEx
    {
        private const string PhoneRegex = @"[+]{0,1}(\d){1,3}[ ]?([-]?((\d)|[ ]){1,12})+";
        private const string EmailRegex = @"[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+";
      

        private static readonly Regex EmailAddressRegex = new Regex(EmailRegex, RegexOptions.IgnoreCase);
        private static readonly Regex PhoneNumberRegex = new Regex(PhoneRegex, RegexOptions.IgnoreCase);
       

        public static string GetRichText(DependencyObject obj)
        {
            return (string)obj.GetValue(RichTextProperty);
        }

        public static void SetRichText(DependencyObject obj, string value)
        {
            obj.SetValue(RichTextProperty, value);
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RichTextProperty =
            DependencyProperty.RegisterAttached("RichText", typeof(string), typeof(RichTextBlockEx), new PropertyMetadata(null, RichTextChanged));

        private static void RichTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            TextBlock textBlock = d as TextBlock;
            if (textBlock == null)
                return;
            string inputString = e.NewValue as string;
            if (string.IsNullOrEmpty(inputString) || string.IsNullOrWhiteSpace(inputString))
            {
                textBlock.Text = string.Empty;
                return;
            }
            textBlock.Inlines.Clear();
            CreateTextBlock(textBlock, inputString);
        }

        private static void CreateTextBlock(TextBlock textBlock, string inputString)
        {
            var resultList = new List<MatchResult>();
            resultList.AddRange(GetMatchResultList(inputString));

            int offset = 0;
            var matchDicOrder = resultList.OrderBy(_ => _.Match.Index);
            foreach (var item in matchDicOrder)
            {
                var match = item.Match;
                if (match.Index >= offset)
                {
                    if (match.Index > 0 && match.Index != offset)
                    {
                        var text = inputString.Substring(offset, match.Index - offset);
                        AddText(textBlock, text);
                    }

                    var content = inputString.Substring(match.Index, match.Length);
                    AddUnderline(textBlock,  content);
                    offset = match.Index + match.Length;
                }
            }

            if (offset < inputString.Length)
            {
                var text = inputString.Substring(offset);
                AddText(textBlock, text);
            }
        }

        private static void AddText(TextBlock textBlock, string text)
        {
            Run run = new Run();
            run.Text = text;
            textBlock.Inlines.Add(run);
        }

        private static void AddUnderline(TextBlock textBlock, string content)
        {
            Run run = new Run();
            run.Text = content;
            run.Foreground = new SolidColorBrush(Colors.Blue);
            Underline underline = new Underline();
            underline.Inlines.Add(run);

            textBlock.Inlines.Add(underline);
        }

      
        private static List<MatchResult> GetMatchResultList(string inputString)
        {
            var matchResultList = new List<MatchResult>();
            foreach (Match match in PhoneNumberRegex.Matches(inputString))
            {
                matchResultList.Add(new MatchResult
                {
                    Match = match,
                    RichTextType = RichTextType.PhoneNumber
                });
            }

            foreach (Match match in EmailAddressRegex.Matches(inputString))
            {
                matchResultList.Add(new MatchResult
                {
                    Match = match,
                    RichTextType = RichTextType.Email
                });
            }


            return matchResultList;
        }

     
    }
}
