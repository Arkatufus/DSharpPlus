﻿using System;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;

namespace DSharpPlus.VoiceNext.EventArgs
{
    /// <summary>
    /// Represents arguments for VoiceReceived events.
    /// </summary>
    public class VoiceReceiveEventArgs : DiscordEventArgs
    {
        /// <summary>
        /// Gets the SSRC of the audio source.
        /// </summary>
        public uint SSRC { get; internal set; }

        /// <summary>
        /// Gets the user that sent the audio data.
        /// </summary>
        public DiscordUser User { get; internal set; }

        /// <summary>
        /// Gets the received data.
        /// </summary>
        public ReadOnlyMemory<byte> Voice { get; internal set; }

        /// <summary>
        /// Gets the format of the received PCM data.
        /// </summary>
        public AudioFormat AudioFormat { get; internal set; }

        /// <summary>
        /// Gets the millisecond duration of the PCM audio sample.
        /// </summary>
        public int AudioDuration { get; internal set; }

        internal VoiceReceiveEventArgs(DiscordClient client) : base(client) { }
    }
}
