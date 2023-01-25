using ScriptPortal.Vegas;
using System;
using System.Collections;
using System.Windows.Forms;
using VegasScriptAssignVideoEventFromAudioEvent;

namespace ExpandFirstVideoEvent
{
    public class EntryPoint
    {
        public void FromVegas(Vegas vegas)
        {
            VegasScriptSettings.Load();
            VegasHelper helper = VegasHelper.Instance(vegas);

            try
            {
                VegasScriptSettingDialog dialog = new VegasScriptSettingDialog();
                dialog.ExpandMargin = VegasScriptSettings.ExpandVideoEventMargin;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    double margin = dialog.ExpandMargin;

                    helper.ExpandFirstVideoEvent(margin);

                    VegasScriptSettings.AssignEventMargin = margin;
                    VegasScriptSettings.Save();
                }
            }
            catch (VegasHelperTrackUnselectedException)
            {
                MessageBox.Show("ビデオトラックが選択されていません。");
            }
            catch (VegasHelperNoneEventsException)
            {
                MessageBox.Show("選択したビデオトラック中にイベントが存在していません。");
            }
        }
    }
}
