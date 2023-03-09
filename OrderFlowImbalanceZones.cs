#region Using declarations
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml.Serialization;
using NinjaTrader.Cbi;
using NinjaTrader.Gui;
using NinjaTrader.Gui.Chart;
using NinjaTrader.Gui.SuperDom;
using NinjaTrader.Gui.Tools;
using NinjaTrader.Data;
using NinjaTrader.NinjaScript;
using NinjaTrader.Core.FloatingPoint;
using NinjaTrader.NinjaScript.DrawingTools;
#endregion

//This namespace holds Indicators in this folder and is required. Do not change it. 
namespace NinjaTrader.NinjaScript.Indicators
{
	public class OrderFlowImbalanceZones : Indicator
	{
		protected override void OnStateChange()
		{
			if (State == State.SetDefaults)
			{
				Description									= @"Creates support and resistance zones from stacked imbalances found in order flow.";
				Name										= "OrderFlowImbalanceZones";
				Calculate									= Calculate.OnBarClose;
				IsOverlay									= true;
				DisplayInDataBox							= true;
				DrawOnPricePanel							= true;
				DrawHorizontalGridLines						= true;
				DrawVerticalGridLines						= true;
				PaintPriceMarkers							= true;
				ScaleJustification							= NinjaTrader.Gui.Chart.ScaleJustification.Right;
				//Disable this property if your indicator requires custom values that cumulate with each new market data event. 
				//See Help Guide for additional information.
				IsSuspendedWhileInactive					= true;
			}
			else if (State == State.Configure)
			{
			}
		}

		protected override void OnBarUpdate()
		{
			//Add your custom indicator logic here.
		}
	}
}

#region NinjaScript generated code. Neither change nor remove.

namespace NinjaTrader.NinjaScript.Indicators
{
	public partial class Indicator : NinjaTrader.Gui.NinjaScript.IndicatorRenderBase
	{
		private OrderFlowImbalanceZones[] cacheOrderFlowImbalanceZones;
		public OrderFlowImbalanceZones OrderFlowImbalanceZones()
		{
			return OrderFlowImbalanceZones(Input);
		}

		public OrderFlowImbalanceZones OrderFlowImbalanceZones(ISeries<double> input)
		{
			if (cacheOrderFlowImbalanceZones != null)
				for (int idx = 0; idx < cacheOrderFlowImbalanceZones.Length; idx++)
					if (cacheOrderFlowImbalanceZones[idx] != null &&  cacheOrderFlowImbalanceZones[idx].EqualsInput(input))
						return cacheOrderFlowImbalanceZones[idx];
			return CacheIndicator<OrderFlowImbalanceZones>(new OrderFlowImbalanceZones(), input, ref cacheOrderFlowImbalanceZones);
		}
	}
}

namespace NinjaTrader.NinjaScript.MarketAnalyzerColumns
{
	public partial class MarketAnalyzerColumn : MarketAnalyzerColumnBase
	{
		public Indicators.OrderFlowImbalanceZones OrderFlowImbalanceZones()
		{
			return indicator.OrderFlowImbalanceZones(Input);
		}

		public Indicators.OrderFlowImbalanceZones OrderFlowImbalanceZones(ISeries<double> input )
		{
			return indicator.OrderFlowImbalanceZones(input);
		}
	}
}

namespace NinjaTrader.NinjaScript.Strategies
{
	public partial class Strategy : NinjaTrader.Gui.NinjaScript.StrategyRenderBase
	{
		public Indicators.OrderFlowImbalanceZones OrderFlowImbalanceZones()
		{
			return indicator.OrderFlowImbalanceZones(Input);
		}

		public Indicators.OrderFlowImbalanceZones OrderFlowImbalanceZones(ISeries<double> input )
		{
			return indicator.OrderFlowImbalanceZones(input);
		}
	}
}

#endregion
