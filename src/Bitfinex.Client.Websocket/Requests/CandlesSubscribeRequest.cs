﻿using System;
using Bitfinex.Client.Websocket.Utils;
using Bitfinex.Client.Websocket.Validations;

namespace Bitfinex.Client.Websocket.Requests
{
    public class CandlesSubscribeRequest : SubscribeRequestBase
    {
        public override string Channel => "candles";
        public string Key { get; set; }


        public CandlesSubscribeRequest(string pair, BitfinexTimeFrame bitfinexTimeFrame)
        {
            BfxValidations.ValidateInput(pair, nameof(pair));

            Key = $"trade:{TimeFrameToKeyCommand(bitfinexTimeFrame)}:{FormatPairToSymbol(pair)}";
        }

        private string TimeFrameToKeyCommand(BitfinexTimeFrame bitfinexTimeFrame)
        {
            return bitfinexTimeFrame.GetStringValue();
        }

        private string FormatPairToSymbol(string pair)
        {
            var formatted = pair
                .Trim()
                .Replace("/", string.Empty)
                .Replace("\\", string.Empty)
                .ToUpper();
            return $"t{formatted}";
        }
    }
}
