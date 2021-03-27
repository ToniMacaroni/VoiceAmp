using System.Text;
using System.Threading.Tasks;
using ComputerInterface;
using ComputerInterface.ViewLib;
using UnityEngine;

namespace VoiceAmp
{
    internal class VoiceAmpView : ComputerView
    {
        private readonly AmpManager _ampManager;
        private readonly UITextInputHandler _textInputHandler;

        public VoiceAmpView(AmpManager ampManager)
        {
            _ampManager = ampManager;
            _textInputHandler = new UITextInputHandler();
        }

        public override void OnShow(object[] args)
        {
            base.OnShow(args);
            Redraw();
        }

        private void Redraw()
        {
            var str = new StringBuilder();

            str.BeginCenter();
            str.MakeBar('-', SCREEN_WIDTH, 0).AppendLine();
            str.BeginColor("ffffff50").AppendLine("Press enter to apply");
            str.AppendLine("Value goes from 1 - 50");
            str.AppendLine($"Current amplifier: x{_ampManager.GetValue()}");
            str.EndColor();
            str.MakeBar('-', SCREEN_WIDTH, 0).EndAlign();

            str.AppendLines(3);

            str.Repeat(" ", 3).AppendClr("> ", "ffffff50").Append(_textInputHandler.Text);

            SetText(str);
        }

        private void SetValue(string val)
        {
            if (int.TryParse(val, out var intVal))
            {
                _ampManager.SetValue(intVal * 0.1f);

                _textInputHandler.Text = "";
                Redraw();
            }
        }

        public override void OnKeyPressed(EKeyboardKey key)
        {
            if (_textInputHandler.HandleKey(key))
            {
                Redraw();
                return;
            }

            if (key == EKeyboardKey.Enter)
            {
                SetValue(_textInputHandler.Text);
                return;
            }

            if (key == EKeyboardKey.Back)
            {
                ReturnToMainMenu();
                return;
            }
        }
    }
}