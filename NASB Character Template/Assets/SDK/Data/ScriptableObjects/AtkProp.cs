using System;

namespace Nick
{
	[Serializable]
	public class AtkProp
	{
		public enum AtkType
		{
			Normal,
			Power,
			Transient,
			Projectile,
			Grab,
			Zdrop
		}

		public enum GrabType
		{
			None = 0,
			Players = 1,
			Projectiles = 2,
			PlayersAndProjectiles = 3,
			Items = 4,
			PlayersAndItems = 5,
			ItemsAndProjectiles = 6,
			All = 7
		}

		public enum KnockbackType
		{
			Normal,
			Set,
			Exact
		}

		public enum DIType
		{
			Any,
			Vertical,
			Horizontal,
			None
		}

		public enum Hit
		{
			All,
			Grounded,
			Airborne
		}

		public enum Direction
		{
			Mid,
			Up,
			Down
		}

		public enum HitInDirection
		{
			All,
			Forward,
			Behind,
			Above,
			Below,
			ForwardOrAbove,
			ForwardOrBelow,
			BehindOrAbove,
			BehindOrBelow,
			ForwardAndAbove,
			ForwardAndBelow,
			BehindAndAbove,
			BehindAndBelow
		}

		public enum EditStyle
		{
			Focused,
			Damage,
			Angle,
			DI,
			Knockback,
			KnockbackMisc,
			Stun,
			Hit,
			Block,
			Lag,
			Launch,
			Grab,
			Misc
		}

		public AtkType type;

		public float dmg = 1f;

		public float dmgmult = 1f;

		public float kbmult = 1f;

		public float angle;

		public Direction dir;

		public DIType di_type;

		public float di_in = 10f;

		public float di_out = 10f;

		public bool reversible;

		public KnockbackType kb_type;

		public float knockback;

		public float kbgain = 1f;

		public float extrakbabovekb;

		public float extrakbmult = 1f;

		public float stun = 30f;

		public float stungain;

		public Hit hitOpponent;

		public HitInDirection hitInDirection;

		public float blockstun = 10f;

		public float blockpush = 1f;

		public float blocklag = 3f;

		public float hitlag = 3f;

		public float hitlagself = 3f;

		public bool launcher;

		public float launchAboveKnockBack;

		public int launcharmorlevel;

		public bool forcejabreset;

		public int grablevel;

		public GrabType grab = GrabType.Players;

		public bool killshot;

		public bool directionalfx;

		public bool unblockable;

		public bool pierceinvincible;
	}
}