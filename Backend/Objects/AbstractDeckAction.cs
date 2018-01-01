﻿using NickAc.Backend.Objects.Implementation.DeckActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NickAc.Backend.Objects
{
    [System.AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    sealed class ActionPropertyIncludeAttribute : Attribute
    { }

    [XmlInclude(typeof(ExecutableRunAction))]
    public abstract class AbstractDeckAction
    {
        public enum DeckActionCategory
        {
            General,
            AutoHotKey,
            OBS
        }
        public abstract DeckActionCategory GetActionCategory();
        public abstract string GetActionName();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="deckDevice"></param>
        /// <returns>True if the button down and button up must be suppressed</returns>
        public abstract bool OnButtonClick(IDeckDevice deckDevice);
        public abstract void OnButtonDown(IDeckDevice deckDevice);
        public abstract void OnButtonUp(IDeckDevice deckDevice);
    }
}