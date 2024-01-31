using System; 
using System.Collections; 
using Server.Misc; 
using Server.Items; 
using Server.Mobiles; 

namespace Server.Mobiles 
{ 
	public class VesperGuard : BaseRanger
	{ 

		[Constructable] 
		public VesperGuard() : base( AIType.AI_Melee, FightMode.Closest, 15, 1, 0.1, 0.2 ) 
		{ 
			Title = "the Swordsman"; 

			SetStr( 1750, 1750 );
			SetDex( 150, 150 );
			SetInt( 61, 75 );

			SetSkill( SkillName.MagicResist, 120.0, 120.0 );
			SetSkill( SkillName.Swords, 120.0, 120.0 );
			SetSkill( SkillName.Tactics,120.0, 120.0 );
			SetSkill( SkillName.Anatomy, 120.0,120.0 );

			AddItem( new Broadsword() );
			AddItem( new WoodenKiteShield() );
			AddItem( new ChainLegs());
			AddItem( new RingmailArms());
			AddItem( new Boots() );
			AddItem( new Helmet() );
			AddItem( new Cloak(793) );
			AddItem( new RingmailGloves() );
			AddItem( new BodySash(801) );

			if ( Female = Utility.RandomBool() ) 
			{ 
				Body = 401; 
				Name = NameList.RandomName( "female" );
								
				AddItem( new ChainChest() );
				
			}
			else 
			{ 
				Body = 400; 			
				Name = NameList.RandomName( "male" ); 

				AddItem( new ChainChest());
				
			}

			Utility.AssignRandomHair( this );
		}

		public VesperGuard( Serial serial ) : base( serial ) 
		{ 
		} 

		public override void Serialize( GenericWriter writer ) 
		{ 
			base.Serialize( writer ); 

			writer.Write( (int) 0 ); // version 
		} 

		public override void Deserialize( GenericReader reader ) 
		{ 
			base.Deserialize( reader ); 

			int version = reader.ReadInt(); 
		} 
	} 
}   