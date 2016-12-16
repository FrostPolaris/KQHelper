using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KQ.Model
{
    /// <summary>
    /// 属性项基类
    /// 提供获取、设置属性的值相关接口
    /// </summary>
    public class PropertyItem
    {
        /// <summary>
        /// 属性名称
        /// </summary>
        public string PropertyName
        {
            get { return theDescriptor.Name; }
        }

        /// <summary>
        /// 属性类型
        /// </summary>
        public Type PropertyType
        {
            get { return theDescriptor.PropertyType; }
        }

        /// <summary>
        /// 属性值
        /// </summary>
        public object PropertyValue
        {
            get { return theDescriptor.GetValue(owningObject); }
            set { theDescriptor.SetValue(owningObject, value); }
        }

        /// <summary>
        /// 持有该属性的对象
        /// </summary>
        protected object owningObject = null;

        /// <summary>
        /// 属性描述
        /// </summary>
        protected PropertyDescriptor theDescriptor = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="inOwningObj">持有属性的对象</param>
        /// <param name="propDesc">属性的描述信息</param>
        public PropertyItem(object inOwningObj, PropertyDescriptor propDesc)
        {
            owningObject = inOwningObj;
            theDescriptor = propDesc;
        }

        /// <summary>
        /// 以指定的类型获取数值
        /// </summary>
        public T GetValueAs<T>()
        {
            return (T)PropertyValue;
        }
    }
}
