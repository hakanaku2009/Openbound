﻿/* 
 * Copyright (C) 2020, Carlos H.M.S. <carlos_judo@hotmail.com>
 * This file is part of OpenBound.
 * OpenBound is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation, either version 3 of the License, or(at your option) any later version.
 * 
 * OpenBound is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty
 * of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License along with OpenBound. If not, see http://www.gnu.org/licenses/.
 */

using Microsoft.Xna.Framework;
using OpenBound.Common;
using OpenBound.GameComponents.Animation;
using OpenBound.GameComponents.Pawn.Unit;
using OpenBound.GameComponents.PawnAction;
using Openbound_Network_Object_Library.Entity;
using System.Collections.Generic;
using System.Linq;

namespace OpenBound.GameComponents.Pawn.UnitProjectiles
{

    public class LightningProjectile1 : Projectile
    {
        public LightningProjectile1(Lightning mobile) : base(mobile, ShotType.S1, Parameter.ProjectileLightningS1ExplosionRadius, Parameter.ProjectileLightningS1BaseDamage)
        {
            //Initializing Flipbook
            FlipbookList.Add(Flipbook.CreateFlipbook(
                mobile.Crosshair.CannonPosition, new Vector2(30f, 31),
                53, 60, "Graphics/Tank/Lightning/Bullet1",
                new List<AnimationInstance>() {
                    new AnimationInstance()
                    { StartingFrame = 0, EndingFrame = 9, TimePerFrame = 1 / 20f }
                }, true, DepthParameter.Projectile, angle));

            //Physics/Trajectory setups
            mass = Parameter.ProjectileLightningS1Mass;
            windInfluence = Parameter.ProjectileLightningS1WindInfluence;

            SpawnTime = 0.7f;
        }

        protected override void Explode()
        {
            base.Explode();
            SpecialEffectBuilder.LightningProjectileThunder(FlipbookList[0].Position, (float)Parameter.Random.NextDouble() * MathHelper.TwoPi);
        }

        protected override void Destroy()
        {
            base.Destroy();

            List<Projectile> pjList = mobile.ProjectileList.Except(mobile.UnusedProjectile).ToList();

            if (pjList.Count() == 0)
                OnFinalizeExecution?.Invoke();
        }
    }

    public class LightningProjectile2 : Projectile
    {
        public LightningProjectile2(Lightning mobile) : base(mobile, ShotType.S2, Parameter.ProjectileLightningS2ExplosionRadius, Parameter.ProjectileLightningS2BaseDamage)
        {
            this.mobile = mobile;

            //Initializing Flipbook
            FlipbookList.Add(Flipbook.CreateFlipbook(
                mobile.Crosshair.CannonPosition, new Vector2(30f, 31),
                53, 60, "Graphics/Tank/Lightning/Bullet1",
                new List<AnimationInstance>() {
                    new AnimationInstance()
                    { StartingFrame = 0, EndingFrame = 9, TimePerFrame = 1 / 20f }
                }, true, DepthParameter.Projectile));

            //Physics/Trajectory setups
            mass = Parameter.ProjectileLightningS2Mass;
            windInfluence = Parameter.ProjectileLightningS2WindInfluence;

            SpawnTime = 0.2;
        }

        protected override void Explode()
        {
            SpecialEffectBuilder.LightningProjectileThunder(FlipbookList[0].Position, (float)Parameter.Random.NextDouble() * MathHelper.TwoPi);
            base.Explode();
        }

        protected override void Destroy()
        {
            base.Destroy();

            List<Projectile> pjList = mobile.ProjectileList.Except(mobile.UnusedProjectile).ToList();

            if (pjList.Count() == 0)
                OnFinalizeExecution?.Invoke();
        }
    }

    public class LightningProjectile3 : Projectile
    {
        public LightningProjectile3(Lightning mobile) : base(mobile, ShotType.SS, Parameter.ProjectileLightningSSExplosionRadius, Parameter.ProjectileLightningSSBaseDamage)
        {
            this.mobile = mobile;

            //Initializing Flipbook
            FlipbookList.Add(Flipbook.CreateFlipbook(
                mobile.Crosshair.CannonPosition, new Vector2(44f, 27f),
                99, 50, "Graphics/Tank/Lightning/Bullet3",
                new List<AnimationInstance>() {
                    new AnimationInstance(){ StartingFrame = 0, EndingFrame = 11, TimePerFrame = 1 / 20f }
                },
                true, DepthParameter.Projectile));

            //Physics/Trajectory setups
            mass = Parameter.ProjectileLightningSSMass;
            windInfluence = Parameter.ProjectileLightningSSWindInfluence;

            SpawnTime = 0.7;
        }

        protected override void Explode()
        {
            //SpecialEffectBuilder.IceProjectile3Explosion(FlipbookList[0].Position);
            base.Explode();
        }

        protected override void Destroy()
        {
            base.Destroy();

            List<Projectile> pjList = mobile.ProjectileList.Except(mobile.UnusedProjectile).ToList();

            if (pjList.Count() == 0)
                OnFinalizeExecution?.Invoke();
        }
    }
}