using ScriptPortal.Vegas;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using VegasScriptHelper;

namespace ExpandFirstVideoEvent
{
    public class EntryPoint: IEntryPoint
    {
        public void FromVegas(Vegas vegas)
        {
            VegasHelper helper = VegasHelper.Instance(vegas);

            // コンボボックッスの既定値の優先度:
            // 1)選択したトラック
            // 2)指定の名前のトラック
            // 3)最初のトラック
            Dictionary<string, VideoTrack> videoKeyValuePairs = helper.GetVideoKeyValuePairs();
            List<string> videoKeyList = videoKeyValuePairs.Keys.ToList();

            if (!videoKeyList.Any())
            {
                MessageBox.Show("ビデオトラックがありません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Dictionary<string, AudioTrack> audioKeyValuePairs = helper.GetAudioKeyValuePairs();
            List<string> audioKeyList = audioKeyValuePairs.Keys.ToList();

            if (!audioKeyList.Any())
            {
                MessageBox.Show("オーディオトラックがありません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            VideoTrack targetVideoTrack = helper.SelectedVideoTrack(false);

            if (targetVideoTrack == null)
            {
                targetVideoTrack = helper.SearchVideoTrackByName(VegasScriptSettings.TargetAssignTrackName);
            }

            string videoTrackKey = targetVideoTrack != null ? helper.GetTrackKey(targetVideoTrack) : videoKeyList[0];

            AudioTrack targetAudioTrack = helper.SelectedAudioTrack(false);

            if (targetAudioTrack == null)
            {
                targetAudioTrack = helper.SearchAudioTrackByName(VegasScriptSettings.TargetAssignTrackName);
            }

            string audioTrackKey = targetAudioTrack != null ? helper.GetTrackKey(targetAudioTrack) : audioKeyList[0];

            try
            {
                VegasScriptSettingDialog dialog = new VegasScriptSettingDialog()
                {
                    VideoTrackNameDataSource = videoKeyList,
                    VideoTrackName = videoTrackKey,
                    AudioTrackNameDataSource = audioKeyList,
                    AudioTrackName= audioTrackKey,
                    ExpandMargin = VegasScriptSettings.ExpandVideoEventMargin
                };

                if (dialog.ShowDialog() == DialogResult.Cancel) { return; }

                double margin = dialog.ExpandMargin;
                VideoTrack videoTrack = videoKeyValuePairs[dialog.VideoTrackName];
                AudioTrack audioTrack = audioKeyValuePairs[dialog.AudioTrackName];

                helper.ExpandFirstVideoEvent(videoTrack, audioTrack, margin);

                VegasScriptSettings.AssignEventMargin = margin;
                VegasScriptSettings.Save();
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
