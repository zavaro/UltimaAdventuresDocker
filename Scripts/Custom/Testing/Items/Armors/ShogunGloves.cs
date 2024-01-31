using System;
using Server;
using Server.Items;


namespace Server.Items
{
              public class ShogunGloves: PlateGloves
{
              
              [Constructable]
              public ShogunGloves()
{

                          Weight = 3;
                          Name = "Shogun Gloves";
                          Hue = 2959;
              
              Attributes.AttackChance = 25;
              Attributes.BonusDex = 10;
              Attributes.BonusHits = 15;
              Attributes.BonusInt = 15;
              Attributes.BonusMana = 10;
              Attributes.BonusStam = 10;
              Attributes.CastRecovery = 4;
              Attributes.CastSpeed = 2;
              Attributes.DefendChance = 20;
              Attributes.LowerManaCost = 20;
              Attributes.LowerRegCost = 30;
              Attributes.NightSight = 1;
              Attributes.ReflectPhysical = 20;
              Attributes.RegenHits = 10;
              Attributes.RegenMana = 5;
              Attributes.RegenStam = 1;
              Attributes.SpellChanneling = 1;
              Attributes.SpellDamage = 30;
              Attributes.WeaponDamage = 20;
              ArmorAttributes.DurabilityBonus = 20;
              ArmorAttributes.SelfRepair = 5;
              ArmorAttributes.MageArmor = 1;
              ColdBonus = 15;
              EnergyBonus = 15;
              FireBonus = 15;
              PhysicalBonus = 15;
              PoisonBonus = 15;
              StrBonus = 20;
                  }
              public ShogunGloves( Serial serial ) : base( serial )
                      {
                      }
              
              public override void Serialize( GenericWriter writer )
                      {
                          base.Serialize( writer );
                          writer.Write( (int) 0 );
                      }
              
              public override void Deserialize(GenericReader reader)
                      {
                          base.Deserialize( reader );
                          int version = reader.ReadInt();
                      }
                  }
              }
