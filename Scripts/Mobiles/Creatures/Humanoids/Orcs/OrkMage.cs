using System;
using Server;
using Server.Misc;
using Server.Items;

namespace Server.Mobiles 
{ 
	[CorpseName( "an orcish corpse" )] 
	public class OrkMage : BaseCreature 
	{ 
		public override int BreathPhysicalDamage{ get{ return 0; } }
		public override int BreathFireDamage{ get{ if ( YellHue < 2 ){ return 100; } else { return 0; } } }
		public override int BreathColdDamage{ get{ if ( YellHue == 3 ){ return 100; } else { return 0; } } }
		public override int BreathPoisonDamage{ get{ if ( YellHue == 2 ){ return 100; } else { return 0; } } }
		public override int BreathEnergyDamage{ get{ return 0; } }
		public override int BreathEffectHue{ get{ if ( YellHue == 1 ){ return 0x488; } else if ( YellHue == 2 ){ return 0xB92; } else if ( YellHue == 3 ){ return 0x5B5; } else { return 0x4FD; } } }
		public override int BreathEffectSound{ get{ return 0x238; } }
		public override int BreathEffectItemID{ get{ return 0x1005; } } // EXPLOSION POTION
		public override bool HasBreath{ get{ return true; } }
		public override double BreathEffectDelay{ get{ return 0.1; } }
		public override void BreathDealDamage( Mobile target, int form ){ base.BreathDealDamage( target, 2 ); }
		public override double BreathDamageScalar{ get{ return 0.4; } }
		public override InhumanSpeech SpeechType{ get{ return InhumanSpeech.Orc; } }

		[Constructable] 
		public OrkMage() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 ) 
		{ 
			((BaseCreature)this).midrace = 5;
			SpeechHue = Server.Misc.RandomThings.GetSpeechHue();

			if ( this.Female = Utility.RandomBool() ) 
			{ 
				Body = 0x191; 
				Name = NameList.RandomName( "ork_female" );
				switch ( Utility.RandomMinMax( 0, 5 ) )
				{
					case 0: Title = "the ork wizard"; break;
					case 1: Title = "the ork sorceress"; break;
					case 2: Title = "the ork mage"; break;
					case 3: Title = "the ork conjurer"; break;
					case 4: Title = "the ork magician"; break;
					case 5: Title = "the ork witch"; break;
				}
			} 
			else 
			{ 
				Body = 0x190; 
				Name = NameList.RandomName( "ork_male" );
				switch ( Utility.RandomMinMax( 0, 5 ) )
				{
					case 0: Title = "the ork wizard"; break;
					case 1: Title = "the ork sorcerer"; break;
					case 2: Title = "the ork mage"; break;
					case 3: Title = "the ork conjurer"; break;
					case 4: Title = "the ork magician"; break;
					case 5: Title = "the ork warlock"; break;
				}
			}

			Server.Misc.IntelligentAction.DressUpWizards( this );

			SetStr( 81, 105 );
			SetDex( 91, 115 );
			SetInt( 96, 120 );

			SetHits( 49, 63 );

			SetDamage( 5, 10 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 15, 20 );
			SetResistance( ResistanceType.Fire, 5, 10 );
			SetResistance( ResistanceType.Poison, 5, 10 );
			SetResistance( ResistanceType.Energy, 5, 10 );

			SetSkill( SkillName.EvalInt, 75.1, 100.0 );
			SetSkill( SkillName.Magery, 75.1, 100.0 );
			SetSkill( SkillName.MagicResist, 75.0, 97.5 );
			SetSkill( SkillName.Tactics, 65.0, 87.5 );
			SetSkill( SkillName.Wrestling, 20.2, 60.0 );
			SetSkill( SkillName.Macing, 20.3, 60.0 );

			Fame = 6000;
			Karma = -6000;

			VirtualArmor = 30;
			PackReg( Utility.RandomMinMax( 2, 10 ) );
			PackReg( Utility.RandomMinMax( 2, 10 ) );
			PackReg( Utility.RandomMinMax( 2, 10 ) );

			if ( 0.7 > Utility.RandomDouble() )
				PackItem( new ArcaneGem() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
			AddLoot( LootPack.MedScrolls );
			AddLoot( LootPack.Potions );
		}

		public override bool ClickTitle{ get{ return false; } }
		public override bool ShowFameTitle{ get{ return false; } }
		public override bool CanRummageCorpses{ get{ return true; } }
		public override bool AlwaysAttackable{ get{ return true; } }
		public override int Meat{ get{ return 1; } }
		public override int TreasureMapLevel{ get{ return Core.AOS ? 1 : 0; } }

		public override void OnAfterSpawn()
		{
			Server.Misc.IntelligentAction.BeforeMyBirth( this );
			base.OnAfterSpawn();
			Server.Misc.MorphingTime.CheckMorph( this );
		}

		public override void OnGotMeleeAttack( Mobile attacker )
		{
			base.OnGotMeleeAttack( attacker );
			Server.Misc.IntelligentAction.DoSpecialAbility( this, attacker );
			Server.Misc.IntelligentAction.CryOut( this );
		}

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );
			Server.Misc.IntelligentAction.DoSpecialAbility( this, defender );
		}

		public override bool OnBeforeDeath()
		{
			if ( Server.Misc.IntelligentAction.HealThySelf( this ) ){ return false; }
			Server.Misc.IntelligentAction.BeforeMyDeath( this );
			Server.Misc.MorphingTime.TurnToSomethingOnDeath( this );
			return base.OnBeforeDeath();
		}

		public OrkMage( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}