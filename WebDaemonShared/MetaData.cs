﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

using MySqlDatabase;
using WebDaemonShared;

namespace MetaData
{
	public class SubmitAddressResponse
	{
		public string deposit_address;
		public string receiving_address;
		public string memo;
	}

	public class StatsRow : ICoreType
	{
		public uint last_bitshares_block;
		public string last_bitcoin_block;
		public string bitcoin_withdraw_address;
	}

	public class IgnoreRow : ICoreType
	{
		public uint uid;
		public string txid;
	}

	public class MarketRow : ICoreType
	{
		public string symbol_pair;
		public decimal ask;
		public decimal bid;
		public decimal ask_max;
		public decimal bid_max;
		public decimal ask_fee_percent;
		public decimal bid_fee_percent;
		public bool up;

		[IgnoreDataMember]
		public uint transaction_processed_uid;

		[IgnoreDataMember]
		public string daemon_url;

		[IgnoreDataMember]
		public uint last_tid;

		[IgnoreDataMember]
		public bool price_discovery;

		[IgnoreDataMember]
		public decimal spread_percent;

		[IgnoreDataMember]
		public decimal window_percent;

		[IgnoreDataMember]
		public bool visible;

		public decimal btc_volume_24h;
		public decimal last_price;
		public string asset_name;
		public decimal realised_spread_percent;
		public decimal price_delta;
		public bool flipped;

		public decimal buy_quantity;
		public decimal sell_quantity;

		public string notes;

		public CurrenciesRow GetBase(Dictionary<string, CurrenciesRow> currencyMap)
		{
			return CurrencyHelpers.FromSymbol(symbol_pair.Split('_')[0], currencyMap);
		}

		public CurrenciesRow GetQuote(Dictionary<string, CurrenciesRow> currencyMap)
		{
			return CurrencyHelpers.FromSymbol(symbol_pair.Split('_')[1], currencyMap);
		}
	}

	public class SenderToDepositRow : ICoreType
	{
		public string deposit_address;
		public string receiving_address;
		public string symbol_pair;
		public uint referral_user;
	}

	public class FeeCollectionRow : ICoreType
	{
		public uint hash;
		public string symbol_pair;
		public string buy_trxid;
		public string sell_trxid;
		public decimal buy_fee;
		public decimal sell_fee;
		public DateTime date;
		public string exception;
		public uint transaction_processed_uid;
		public string start_txid;
		public string end_txid;
	}

	public class ReferralUserRow : ICoreType
	{
		public uint uid;
		public string bitshares_username;
		public string bitcoin_address;
	}

	public class ReferralAddressRow : ICoreType
	{
		public uint referral_user;
		public string address;
	}

	public class LastPriceAndDelta
	{
		public decimal last_price;
		public decimal price_delta;
	}

	public class ConfigRow : ICoreType
	{
		public string email_from;
		public string email_to;
	}

	public class CurrenciesRow : ICoreType
	{
		public string symbol;
		public bool bitshares;
		public bool uia;

		public override string ToString()
		{
			return symbol;
		}
	}
}
