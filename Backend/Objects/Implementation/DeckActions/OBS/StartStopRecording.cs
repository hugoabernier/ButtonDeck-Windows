﻿using NickAc.Backend.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NickAc.Backend.Objects.Implementation.DeckActions.OBS
{
    public class StartStopRecording : AbstractDeckAction
    {
        static bool firstTime = false;
        public enum RecordingState
        {
            Start,
            Stop
        }
        [ActionPropertyInclude]
        [ActionPropertyDescription("Action")]
        [ActionPropertyUpdateImageOnChanged]
        public RecordingState RecordAction { get; set; }
        public override AbstractDeckAction CloneAction()
        {
            return new StartStopRecording();
        }

        public override DeckActionCategory GetActionCategory()
        {
            return DeckActionCategory.OBS;
        }

        public override string GetActionName()
        {
            if (!firstTime) {
                firstTime ^= true;
                return "Start/Stop Recording";
            }
            switch (RecordAction) {
                case RecordingState.Start:
                    return "Start Recording";
                case RecordingState.Stop:
                    return "Stop Recording";
            }
            return "Start/Stop Recording";
        }

        public override void OnButtonDown(DeckDevice deckDevice)
        {
        }

        public override void OnButtonUp(DeckDevice deckDevice)
        {
            if (OBSUtils.IsConnected) {
                switch (RecordAction) {
                    case RecordingState.Start:
                        OBSUtils.StartRecording();
                        break;
                    case RecordingState.Stop:
                        OBSUtils.StopRecording();
                        break;
                }
            }
        }
    }
}
