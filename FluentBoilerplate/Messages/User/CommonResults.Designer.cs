﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FluentBoilerplate.Messages.User {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class CommonResults {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal CommonResults() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("FluentBoilerplate.Messages.User.CommonResults", typeof(CommonResults).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Property &apos;{0}.{1}&apos; must not be null.
        /// </summary>
        public static string PropertyCannotBeNull {
            get {
                return ResourceManager.GetString("PropertyCannotBeNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Property &apos;{0}.{1}&apos; exceeds length of &apos;{2}&apos;.
        /// </summary>
        public static string StringPropertyIsTooLong {
            get {
                return ResourceManager.GetString("StringPropertyIsTooLong", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Property &apos;{0}.{1}&apos; does not meet or exceed length of &apos;{2}&apos;.
        /// </summary>
        public static string StringPropertyIsTooShort {
            get {
                return ResourceManager.GetString("StringPropertyIsTooShort", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The validation attempt &apos;{0}&apos; was not applicable to the selected target.
        /// </summary>
        public static string ValidationNotApplicable {
            get {
                return ResourceManager.GetString("ValidationNotApplicable", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The validation was successful.
        /// </summary>
        public static string ValidationSuccess {
            get {
                return ResourceManager.GetString("ValidationSuccess", resourceCulture);
            }
        }
    }
}
