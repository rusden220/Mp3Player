﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.34014
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mp3Player.Properties {
    using System;
    
    
    /// <summary>
    ///   Класс ресурса со строгой типизацией для поиска локализованных строк и т.д.
    /// </summary>
    // Этот класс создан автоматически классом StronglyTypedResourceBuilder
    // с помощью такого средства, как ResGen или Visual Studio.
    // Чтобы добавить или удалить член, измените файл .ResX и снова запустите ResGen
    // с параметром /str или перестройте свой проект VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Возвращает кэшированный экземпляр ResourceManager, использованный этим классом.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Mp3Player.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Перезаписывает свойство CurrentUICulture текущего потока для всех
        ///   обращений к ресурсу с помощью этого класса ресурса со строгой типизацией.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot; ?&gt;
        ///&lt;Items&gt;&lt;!--main Elem--&gt;
        ///	&lt;Item name=&quot;File&quot;&gt;
        ///		&lt;Handler type =&quot;cs&quot; value=&quot;Mp3Player.UI.MainMenuStrip.MainMenuFile&quot;/&gt;
        ///	&lt;/Item&gt;
        ///	&lt;Item name=&quot;Function&quot;&gt;
        ///		&lt;Handler type =&quot;cs&quot; value=&quot;Mp3Player.UI.MainMenuStrip.MainMenuFunction&quot;/&gt;
        ///			&lt;Item name=&quot;Play&quot;&gt;
        ///				&lt;Handler type =&quot;cs&quot; value=&quot;Mp3Player.UI.MainMenuStrip.MainMenuFunction&quot;/&gt;
        ///			&lt;/Item&gt;
        ///			&lt;Item name=&quot;Pause&quot;&gt;
        ///				&lt;Handler type =&quot;cs&quot; value=&quot;Mp3Player.UI.MainMenuStrip.MainMenuFunction&quot;/&gt;
        ///				&lt;Item name=&quot;Stop&quot;&gt;        /// [остаток строки не уместился]&quot;;.
        /// </summary>
        internal static string MainMenu {
            get {
                return ResourceManager.GetString("MainMenu", resourceCulture);
            }
        }
    }
}
