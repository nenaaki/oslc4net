﻿//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.42000
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

namespace OSLC4Net.Client.Properties {
    using System;
    
    
    /// <summary>
    ///   ローカライズされた文字列などを検索するための、厳密に型指定されたリソース クラスです。
    /// </summary>
    // このクラスは StronglyTypedResourceBuilder クラスが ResGen
    // または Visual Studio のようなツールを使用して自動生成されました。
    // メンバーを追加または削除するには、.ResX ファイルを編集して、/str オプションと共に
    // ResGen を実行し直すか、または VS プロジェクトをビルドし直します。
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   このクラスで使用されているキャッシュされた ResourceManager インスタンスを返します。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("OSLC4Net.Client.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   すべてについて、現在のスレッドの CurrentUICulture プロパティをオーバーライドします
        ///   現在のスレッドの CurrentUICulture プロパティをオーバーライドします。
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
        ///   OSLCC002: An error occurred attempting to login to the Jazz server.  Status code {0}.  Server location: {1}. に類似しているローカライズされた文字列を検索します。
        /// </summary>
        public static string JazzAuthErrorException {
            get {
                return ResourceManager.GetString("JazzAuthErrorException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   OSLCC001: Unable to authenticate user {0} with the Jazz server at {1}. に類似しているローカライズされた文字列を検索します。
        /// </summary>
        public static string JazzAuthFailedException {
            get {
                return ResourceManager.GetString("JazzAuthFailedException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   OSLCC004: The requested resource could not be found.  Resource: {0}  Value: {1}. に類似しているローカライズされた文字列を検索します。
        /// </summary>
        public static string ResourceNotFoundException {
            get {
                return ResourceManager.GetString("ResourceNotFoundException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   OSLCC003: An error occurred processing the root services document.  Server location: {0}. に類似しているローカライズされた文字列を検索します。
        /// </summary>
        public static string RootServicesException {
            get {
                return ResourceManager.GetString("RootServicesException", resourceCulture);
            }
        }
    }
}
