using System;
using Server;
using Server.Spells.First;
using Server.Targeting;

namespace Server.Items
{
	public class FeebleMagicStaff : BaseMagicStaff
	{
		[Constructable]
		public FeebleMagicStaff() : base( MagicStaffEffect.Charges, 1, 25 )
		{
			IntRequirement = 10;
			SkillBonuses.SetValues( 1, SkillName.Magery, 10 );
		}

		public override void AddNameProperties( ObjectPropertyList list )
		{
			base.AddNameProperties( list );
			list.Add( 1070722, "1st Circle of Power" );
		}

		public FeebleMagicStaff( Serial serial ) : base( serial )
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

		public override void OnMagicStaffUse( Mobile from )
		{
			Cast( new FeeblemindSpell( from, this ) );
		}
	}
}