using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SnailFis.Model;

namespace SnailFis.WebCommon
{
    public class ValidationAttribute : Attribute
    {
        public ValidationAttribute(int maxLength, string name, bool isRequired, int minLength = 0)
        {
            MaxLength = maxLength;
            Name = name;
            IsRequired = isRequired;
            MinLength = minLength;
        }
        public int MaxLength { get; set; }
        public string Name { get; set; }
        public bool IsRequired { get; set; }
        public int MinLength { get; set; }

    }

    public static class ValidationModel
    {
        public static MessageModel Validate(object obj)
        {
            var msg = new MessageModel() { Success = true };
            var t = obj.GetType();
            var properties = t.GetProperties();//获取所有属性
            foreach (var property in properties)
            {
                if (!property.IsDefined(typeof(ValidationAttribute), false)) continue;//验证是否加上ValidationAttribute标记

                object[] objs = property.GetCustomAttributes(typeof(ValidationAttribute), true);//获取特性
                var maxLength = ((ValidationAttribute)objs[0]).MaxLength;
                var name = ((ValidationAttribute)objs[0]).Name;
                var isRequired = ((ValidationAttribute)objs[0]).IsRequired;
                var minLength = ((ValidationAttribute)objs[0]).MinLength;

                //获取属性的值
                var propertyValue = property.GetValue(obj) as string;
                if (string.IsNullOrEmpty(propertyValue) && isRequired)
                {
                    return new MessageModel() { Success = false, Msg = $"{name}不可为空" };
                }
                if (!string.IsNullOrEmpty(propertyValue) && propertyValue.Length > maxLength)
                {
                    return new MessageModel() { Success = false, Msg = $"{name}长度不可超过{maxLength}" };
                }
            }
            return msg;
        }
    }
}