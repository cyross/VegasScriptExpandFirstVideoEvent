﻿//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.42000
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExpandFirstVideoEvent.Properties
{


    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.4.0.0")]
    internal sealed partial class SupportedAudioFileSettings : global::System.Configuration.ApplicationSettingsBase
    {

        private static SupportedAudioFileSettings defaultInstance = ((SupportedAudioFileSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new SupportedAudioFileSettings())));

        public static SupportedAudioFileSettings Default
        {
            get
            {
                return defaultInstance;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(".wav")]
        public string Wave
        {
            get
            {
                return ((string)(this["Wave"]));
            }
            set
            {
                this["Wave"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(".mp3")]
        public string MP3
        {
            get
            {
                return ((string)(this["MP3"]));
            }
            set
            {
                this["MP3"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(".ogg")]
        public string Ogg
        {
            get
            {
                return ((string)(this["Ogg"]));
            }
            set
            {
                this["Ogg"] = value;
            }
        }
    }
}
