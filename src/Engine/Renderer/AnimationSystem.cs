using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Engine
{
	public class AnimationSystem : IEcsRunSystem
	{
		public void Run(IEcsSystems systems)
		{
			foreach (int entity in m_animationFilter.Value)
			{
				ref RendererComponent rendererComp = ref m_rendererPool.Value.Get(entity);
				ref AnimationComponent animationComp = ref m_animationPool.Value.Get(entity);
				animationComp.AnimationCurrentTime += EngineData.DeltaTime;
				animationComp.AnimationCurrentTime = animationComp.AnimationCurrentTime > animationComp.AnimationTime ? 0 : animationComp.AnimationCurrentTime;
				rendererComp.Sprite = SpriteUtility.GetSprite(animationComp.SpritesNames[(int)(animationComp.AnimationCurrentTime * animationComp.SpritesNumber / animationComp.AnimationTime)]);
			}
			foreach (int entity in m_timedAnimationFilter.Value)
			{
				ref RendererComponent rendererComp = ref m_rendererPool.Value.Get(entity);
				ref TimedAnimationComponent timedAnimComp = ref m_timedAnimationPool.Value.Get(entity);
				timedAnimComp.AnimationCurrentTime += EngineData.DeltaTime;
				if (timedAnimComp.AnimationCurrentTime > timedAnimComp.SpritesTime[timedAnimComp.CurrentSprite])
				{
					timedAnimComp.CurrentSprite++;
					timedAnimComp.CurrentSprite = timedAnimComp.CurrentSprite >= timedAnimComp.SpritesNumber ? 0 : timedAnimComp.CurrentSprite;
					timedAnimComp.AnimationCurrentTime = 0f;
				}
				rendererComp.Sprite = SpriteUtility.GetSprite(timedAnimComp.SpritesNames[timedAnimComp.CurrentSprite]);
			}
		}

		private EcsFilterInject<Inc<TransformComponent, RendererComponent, AnimationComponent>> m_animationFilter;
		private EcsFilterInject<Inc<TransformComponent, RendererComponent, TimedAnimationComponent>> m_timedAnimationFilter;
		private EcsPoolInject<RendererComponent> m_rendererPool;
		private EcsPoolInject<AnimationComponent> m_animationPool;
		private EcsPoolInject<TimedAnimationComponent> m_timedAnimationPool;
	}
}
