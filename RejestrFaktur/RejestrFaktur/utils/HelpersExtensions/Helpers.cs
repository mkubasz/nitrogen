using System.Text;
using System.Web.Mvc;

namespace RejestrFaktur.utils.HelpersExtensions
{
    public static class Helpers
    {
        //helpery
        public static MvcHtmlString ListaAtrybuty(this HtmlHelper html, string nazwa, object obj)
        {
            StringBuilder sBuilder = new StringBuilder("");
            if (obj != null)
            {
                sBuilder.AppendFormat("<select name =\"{0}\">{1}</select>", nazwa, HelpersUtils.WypiszAtrybutyObiektu(obj));
            }
            return MvcHtmlString.Create(sBuilder.ToString());
        }

        public static MvcHtmlString ListaAtrybuty(this HtmlHelper html, string nazwa, object obj, object htmlAttributes)
        {
            StringBuilder sBuilder = new StringBuilder("");
            if (obj != null)
            {
                sBuilder.AppendFormat("<select name =\"{0}\" {1} >{2}</select>", nazwa, HelpersUtils.WyliczHtmlAttributes(htmlAttributes), HelpersUtils.WypiszAtrybutyObiektu(obj));
            }
            return MvcHtmlString.Create(sBuilder.ToString());
        }
    }
}