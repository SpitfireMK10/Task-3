using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POE_Term_2
{
    class WizardUnit : Unit
    {

        public int Xpos
        {
            get { return xPos; }
            set { xPos = value; }
        }

        public int Ypos
        {
            get { return yPos; }
            set { yPos = value; }
        }

        public int health
        {
            get { return Health; }
            set { Health = value; }
        }

        public int speed
        {
            get { return Speed; }
            set { Speed = value; }
        }

        public int attack
        {
            get { return Attack; }
            set { Attack = value; }
        }

        public int attackRange
        {
            get { return AttackRange; }
            set { AttackRange = value; }
        }

        public int faction
        {
            get { return Faction; }
            set { Faction = value; }
        }

        public string symbol
        {
            get { return Symbol; }
            set { Symbol = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public WizardUnit(int X_position, int Y_position, int Health, int Attack, int Speed, int Attack_range, int Faction1, string Symbol1, string name1)
        {
            Xpos = X_position;
            Ypos = Y_position;
            health = Health;
            attack = Attack;
            speed = Speed;
            attackRange = Attack_range;
            faction = Faction1;
            symbol = Symbol1;
            name = name1;
        }

        public override bool withinAttackRange(Unit u)
        {
            if (u.GetType() == typeof(WizardUnit))
            {
                WizardUnit W = (WizardUnit)u;
                if (DistanceTo(u) <= attackRange)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public override void NewPos(Direction direction)
        {
            switch (direction)
            {
                case Direction.North:
                    {
                        Ypos -= Speed;
                        break;
                    }
                case Direction.East:
                    {
                        Xpos += Speed;
                        break;
                    }
                case Direction.South:
                    {
                        Ypos += Speed;
                        break;
                    }
                case Direction.West:
                    {
                        Xpos -= Speed;
                        break;
                    }
            }
        }

        public override void combatWithUnit(Unit u)
        {
            if (u.GetType() == typeof(MeleeUnit))
            {
                Health -= ((MeleeUnit)u).attack;
            }
            else if (u.GetType() == typeof(RangedUnit))
            {
                Health -= ((RangedUnit)u).attack;
            }
            else if (u.GetType() == typeof(WizardUnit))
            {
                Health -= ((WizardUnit)u).attack;
            }
        }
        public override bool isDead()
        {
            if (Health < 1)
            {
                return true;
            }
            else

                return false;
        }

        public override Unit UnitDistance(Unit[] units)
        {
            Unit closest = this;
            int closestDist = 50;
            foreach (Unit u in units)
            {
                if (((MeleeUnit)u).faction != faction)
                {
                    if (DistanceTo((MeleeUnit)u) < closestDist)
                    {
                        closest = u;
                        closestDist = DistanceTo((MeleeUnit)u);
                    }
                }
                if (u.GetType() == typeof(MeleeUnit))
                {
                    if (DistanceTo((MeleeUnit)u) < closestDist)
                    {
                        closest = u;
                        closestDist = DistanceTo(u);
                    }
                }
                else if (u.GetType() == typeof(RangedUnit))
                {
                    if (DistanceTo((RangedUnit)u) < closestDist)
                    {
                        closest = u;
                        closestDist = DistanceTo(u);
                    }
                }
                else if (u.GetType() == typeof(WizardUnit))
                {
                    if (DistanceTo((WizardUnit)u) < closestDist)
                    {
                        closest = u;
                        closestDist = DistanceTo(u);
                    }
                }
            }

            return closest;

        }

        public override string toString()
        {
            return "Name: " + name + "\r\nFaction: " + faction + "\r\nSymbol: " + Symbol + "\r\nRange: " + attackRange + "\r\nAttack Damage: " + attack + "\r\nHealth: " + health + "\r\nSpeed: " + speed + "\r\nY Postion: " + Xpos + "\r\nX Postion: " + Ypos;
        }

        public Direction Directionto(Unit u)
        {
            if (u.GetType() == typeof(WizardUnit))
            {
                WizardUnit m = (WizardUnit)u;
                if (m.Xpos < Xpos)
                {
                    return Direction.North;
                }
                else if (m.Xpos > Xpos)
                {
                    return Direction.South;
                }
                else if (m.Ypos < Ypos)
                {
                    return Direction.West;
                }
                else
                {
                    return Direction.East;
                }
            }
            else
            {
                return Direction.North;
            }

        }

        private int DistanceTo(Unit u)
        {
            if (u.GetType() == typeof(WizardUnit))
            {
                WizardUnit w = (WizardUnit)u;
                int d = Math.Abs(Xpos - w.Xpos) + Math.Abs(Ypos - w.Ypos);
                return d;
            }
            else
            {
                return 0;
            }
        }
    }
}
