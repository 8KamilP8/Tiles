using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;


public class GameLogMessage 
{
    private string[] stringMessage;
    private float lifeTime;
    private Sprite[][] icons;
    private bool[] objectOrder;

    public event System.EventHandler OnLifeTimeExceeded;

    private GameLogMessage(int stringMessageSize, int iconMessageSize) {
        if(stringMessageSize > 0) {
            stringMessage = new string[stringMessageSize];
        }
        if (iconMessageSize > 0) {
            icons = new Sprite[iconMessageSize][];
        }
        objectOrder = new bool[iconMessageSize + stringMessageSize];
    }

    public void SetLifeTime(float time) {
        lifeTime = time;
    }

    public void GetDataObject(int i) {
       
    }
    public int GetMessageLength() {
        return objectOrder.Length;
    }
    public override string ToString() {
        return "GLM: " + stringMessage;
    }

    public void OnClock(object sender, EventArgs args) {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0f) {
            OnLifeTimeExceeded?.Invoke(this, null);
        }
    }

    public class Builder {

        private GameLogMessage glm;
        private System.Text.StringBuilder stringBuilder;
        private int iterator = 0;
        private int iconsIterator = 0;
        private int stringsIterator = 0;
        private bool isIcon;
        /// <summary>
        /// GameLogMessage.Builder is used for creating GameLogMessage objects. Firstly it is required to set the size of message (number of strings and icon chunks)
        /// </summary>
        /// <param name="messageSize"></param>
        /// <param name="iconMessageSize"></param>
        public Builder(int stringMessageSize, int iconMessageSize, bool startWithIcon) {
            isIcon = startWithIcon;
            glm = new GameLogMessage(stringMessageSize, iconMessageSize);
        }
        public void AppendToString(string @string) {
            AppendWithStringBuilder(@string);
        }
        public void AppendToString(int @int) {
            AppendWithStringBuilder(@int);
        }
        public void AppendToString(float @float) {
            AppendWithStringBuilder(@float);
        }
        public void AppendToString(double @double) {
            AppendWithStringBuilder(@double);
        }
        private void AppendWithStringBuilder(object obj) {
            stringBuilder.Append(obj);
        }
        public void AppendBuildString() {
            if (isIcon) {
                throw new IncorrectBuilderCall("Should be AppendIcons or AppendIcon called, multiple strings should be appended in one string");
            }            
            glm.stringMessage[stringsIterator] = stringBuilder.ToString();
            stringsIterator++;
            NextObject();
        }
        private void NextObject() {
            glm.objectOrder[iterator] = isIcon;
            iterator++;
            isIcon = !isIcon;
        }
        public void AppendIcon(Sprite sprite) {
            if (!isIcon) {
                throw new IncorrectBuilderCall("Should be AppendString called first or AppendIcons instead of multiple AppendIcon calls");
            }
            glm.icons[iconsIterator] = new Sprite[1];
            glm.icons[iconsIterator][0] = sprite;
            NextObject();
        }
        public void AppendIcons(Sprite[] sprite) {
            if (!isIcon) {
                throw new IncorrectBuilderCall("Should be AppendString called first or AppendIcons instead of multiple AppendIcon calls");
            }
            glm.icons[iconsIterator] = sprite;
            NextObject();
        }
        public GameLogMessage GetProduct() {            
            return glm;
        }
    }
}

public class IncorrectBuilderCall : Exception {

    public IncorrectBuilderCall() {}

    public IncorrectBuilderCall(string message) : base(message) {}

    public IncorrectBuilderCall(string message, Exception innerException) : base(message, innerException) {}

    protected IncorrectBuilderCall(SerializationInfo info, StreamingContext context) : base(info, context) {}
}
