using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AycemOtomasyon
{
    public static class Extension
    {
        public static Guid ComboboxSelectedValue(this object comboBoxItem)
        {
            var text = comboBoxItem.ToString().Replace(" ", "");
            text = text.Substring(text.IndexOf("Value="), text.IndexOf("}") - text.IndexOf("Value=")).Replace("Value=", "");
            return new Guid(text);
        }

        public static int ToInt(this object text)
        {
            return Convert.ToInt32(text);
        }

        public static Guid GetValueByText(this ComboBox comboBox, string text)
        {
            var index = comboBox.FindStringExact(text);
            var item = (ComboBoxItem)comboBox.Items[index];
            return new Guid(item.Value.ToString());
        }

        public static string GetDescription(this Enum GenericEnum) //Hint: Change the method signature and input paramter to use the type parameter T
        {
            Type genericEnumType = GenericEnum.GetType();
            MemberInfo[] memberInfo = genericEnumType.GetMember(GenericEnum.ToString());
            if ((memberInfo != null && memberInfo.Length > 0))
            {
                var _Attribs = memberInfo[0].GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
                if ((_Attribs != null && _Attribs.Count() > 0))
                {
                    return ((System.ComponentModel.DescriptionAttribute)_Attribs.ElementAt(0)).Description;
                }
            }
            return GenericEnum.ToString();
        }
    }

    public class ComboBoxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return this.Text;
        }
    }
}
