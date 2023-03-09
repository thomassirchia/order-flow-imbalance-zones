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

				SyntheticBarSize									= 1;
				MinNumberOfImbalances							= 3;
				ImbalanceRatio										= 3.0;
				WinningSideMinSize								= 0.0;
				LosingSideMinSize									= 1.0;
				MinDeltaForImbalance							= 0;
				ConcentratedImbalancesBarRatio		= 0.33;
				NumberInConcentratedImbalances		= 4;
				AllowStacked1TickGap							= false;
				DrawSupportResistanceZones				= false;
				
			}
			else if (State == State.Configure)
			{
			}
		}

		protected override void OnBarUpdate()
		{
			//Add your custom indicator logic here.
		}

		#region Properties
		[NinjaScriptProperty]
		[Range(1, int.MaxValue)]
		[Display(Name="Synthetic Bar Size", Order=1, GroupName="Imbalances")]
		public int SyntheticBarSize
		{ get; set; }
		
		[NinjaScriptProperty]
		[Range(0, int.MaxValue)]
		[Display(Name="Min # of Stacked Imbalances", Order=2, GroupName="Imbalances")]
		public int MinNumberOfImbalances
		{ get; set; }
		
		[NinjaScriptProperty]
		[Range(0, double.MaxValue)]
		[Display(Name="Ratio for Imbalance", Order=3, GroupName="Imbalances")]
		public double ImbalanceRatio
		{ get; set; }
		
		
		[NinjaScriptProperty]
		[Range(0, int.MaxValue)]
		[Display(Name="Min Delta for Imbalance", Order=4, GroupName="Imbalances")]
		public int MinDeltaForImbalance
		{ get; set; }
		
		[NinjaScriptProperty]
		[Range(0, double.MaxValue)]
		[Display(Name="Min Size for Winning Imbalance Side", Order=5, GroupName="Imbalances")]
		public double WinningSideMinSize
		{ get; set; }
		
		[NinjaScriptProperty]
		[Range(0, double.MaxValue)]
		[Display(Name="Min Size for Losing Imbalance Side", Order=6, GroupName="Imbalances")]
		public double LosingSideMinSize
		{ get; set; }
		
		[NinjaScriptProperty]
		[Display(Name="Allow 1 tick gap in imbalances", Order=7, GroupName="Imbalances")]
		public bool AllowStacked1TickGap
		{ get; set; }
		
		[NinjaScriptProperty]
		[Display(Name="Draw Support/Resistance Zones", Order=8, GroupName="Drawings")]
		public bool DrawSupportResistanceZones
		{ get; set; }

		[NinjaScriptProperty]
		[Range(0, double.MaxValue)]
		[Display(Name="Concentrated Imbalance to Bar Ratio", Order=9, GroupName="Imbalances")]
		public double ConcentratedImbalancesBarRatio
		{ get; set; }
		
		[NinjaScriptProperty]
		[Range(0, int.MaxValue)]
		[Display(Name="# of Imbalances in Concentrated Imbalance Cluster", Order=10, GroupName="Imbalances")]
		public int NumberInConcentratedImbalances
		{ get; set; }
		#endregion
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
