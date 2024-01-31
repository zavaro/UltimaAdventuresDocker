
////////////////////////////////////////
//                                    //
//   Generated by CEO's YAAAG - V1.2  //
// (Yet Another Arya Addon Generator) //
//                                    //
////////////////////////////////////////
using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class hex_HemppatchSouthAddon : BaseAddon
	{
        private static int[,] m_AddOnSimpleComponents = new int[,] {
			  {2324, -1, -1, 0}, {2324, -1, 0, 0}, {2324, -1, 1, 0}// 1	2	3	
			, {2324, -1, 2, 0}, {2324, 0, -1, 0}, {2324, 0, 0, 0}// 4	5	6	
			, {2324, 0, 1, 0}, {2324, 0, 2, 0}, {2324, 1, -1, 0}// 7	8	9	
			, {2324, 1, 0, 1}, {2324, 1, 1, 0}, {2324, 1, 2, 0}// 10	11	12	
			, {6022, -1, 2, 1}, {6024, 1, -1, 1}, {6025, 1, 2, 1}// 13	14	15	
			, {6023, -1, -1, 1}, {6019, 1, 1, 1}, {6019, 1, 0, 1}// 16	17	18	
			, {6021, -1, 0, 1}, {6021, -1, 1, 1}, {5368, 1, 0, 1}// 19	20	21	
			, {4090, -1, 2, 3}, {6018, 0, 2, 1}, {6019, -2, -1, 0}// 22	23	28	
			, {6019, -2, 0, 0}, {6019, -2, 1, 0}, {6019, -2, 2, 0}// 29	30	31	
			, {6020, -1, 3, 0}, {6020, 0, 3, 0}, {6020, 1, 3, 0}// 32	33	34	
			, {6021, 2, -1, 0}, {6021, 2, 0, 0}, {6021, 2, 1, 0}// 35	36	37	
			, {6021, 2, 2, 0}, {6018, -1, -2, 0}, {6018, 0, -2, 0}// 38	39	40	
			, {6018, 1, -2, 0}// 41	
		};

 
            
		public override BaseAddonDeed Deed
		{
			get
			{
				return new hex_HemppatchSouthAddonDeed();
			}
		}

		[ Constructable ]
		public hex_HemppatchSouthAddon()
		{

            for (int i = 0; i < m_AddOnSimpleComponents.Length / 4; i++)
                AddComponent( new AddonComponent( m_AddOnSimpleComponents[i,0] ), m_AddOnSimpleComponents[i,1], m_AddOnSimpleComponents[i,2], m_AddOnSimpleComponents[i,3] );


			AddComplexComponent( (BaseAddon) this, 3220, 0, 0, 2, 663, -1, "", 1);// 24
			AddComplexComponent( (BaseAddon) this, 3220, 0, 1, 2, 663, -1, "", 1);// 25
			AddComplexComponent( (BaseAddon) this, 3220, 0, 2, 2, 663, -1, "", 1);// 26
			AddComplexComponent( (BaseAddon) this, 3220, 0, -1, 0, 663, -1, "", 1);// 27

		}

		public hex_HemppatchSouthAddon( Serial serial ) : base( serial )
		{
		}

        private static void AddComplexComponent(BaseAddon addon, int item, int xoffset, int yoffset, int zoffset, int hue, int lightsource)
        {
            AddComplexComponent(addon, item, xoffset, yoffset, zoffset, hue, lightsource, null, 1);
        }

        private static void AddComplexComponent(BaseAddon addon, int item, int xoffset, int yoffset, int zoffset, int hue, int lightsource, string name, int amount)
        {
            AddonComponent ac;
            ac = new AddonComponent(item);
            if (name != null && name.Length > 0)
                ac.Name = name;
            if (hue != 0)
                ac.Hue = hue;
            if (amount > 1)
            {
                ac.Stackable = true;
                ac.Amount = amount;
            }
            if (lightsource != -1)
                ac.Light = (LightType) lightsource;
            addon.AddComponent(ac, xoffset, yoffset, zoffset);
        }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( 0 ); // Version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	public class hex_HemppatchSouthAddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				return new hex_HemppatchSouthAddon();
			}
		}

		[Constructable]
		public hex_HemppatchSouthAddonDeed()
		{
			Name = "Hemp patch South";
		}

		public hex_HemppatchSouthAddonDeed( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( 0 ); // Version
		}

		public override void	Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}