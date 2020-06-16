﻿using Microsoft.Xna.Framework;
using OpenBound.Common;
using OpenBound.GameComponents.Animation;
using OpenBound.GameComponents.Audio;

namespace OpenBound.GameComponents.Pawn.UnitProjectiles
{
    public class ThorProjectile : BeamDummyProjectile
    {
        ThorSatellite thor;

        public ThorProjectile(Mobile mobile, ThorSatellite thor, Vector2 position, float beamAngle)
            : base(mobile, position, beamAngle, Parameter.ProjectileThorExplosionRadius, 0, Parameter.ProjectileThorBaseDamage + thor.Level * Parameter.ProjectileThorBaseDamagePerLevel, 0, false)
        {
            this.thor = thor;
        }

        protected override void Explode()
        {
            base.Explode();

            //Special effects + thor animation
            thor.Shot(Position);

            AudioHandler.PlaySoundEffect("Audio/SFX/Tank/Blast/AdukaS2");
        }

        protected override int CalculateDamage(Mobile mobile)
        {
            int exp = base.CalculateDamage(mobile);
            thor.GainExperience(exp);
            return exp;
        }
    }
}