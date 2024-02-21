using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Engine
{
	public class AnimationSystem : IEcsRunSystem
	{
		public void Run(IEcsSystems systems)
		{
			foreach (int entity in m_multiAnimationsNotInitFilter.Value)
			{
				ref AnimationComponent animationComp = ref m_animationPool.Value.Add(entity);
				ref MultiAnimationComponent multiAnimationComp = ref m_multiAnimationPool.Value.Get(entity);
				animationComp.SpritesNames = multiAnimationComp.SpritesNames;
			}
			foreach (int entity in m_multiAnimationFilter.Value)
			{
				ref MultiAnimationComponent multiAnimationComp = ref m_multiAnimationPool.Value.Get(entity);

				if (multiAnimationComp.HaveAnimationChanged)
				{
					ref AnimationComponent animationComp = ref m_animationPool.Value.Get(entity);
					int animationIndex = multiAnimationComp.Animations[multiAnimationComp.CurrentAnimation];

					animationComp.SpritesNumber = multiAnimationComp.AnimationsSpritesNumbers[animationIndex];
					animationComp.AnimationTime = multiAnimationComp.AnimationsTime[animationIndex];
					animationComp.AnimationCurrentTime = 0;
					animationComp.AnimationStartIndex = multiAnimationComp.AnimationsStartIndex[animationIndex];

					multiAnimationComp.HaveAnimationChanged = false;
				}
			}

			foreach (int entity in m_multiTimedAnimationsNotInitFilter.Value)
			{
				ref TimedAnimationComponent timedAnimComp = ref m_timedAnimationPool.Value.Add(entity);
				ref MultiTimedAnimationComponent multiTimedAnimComp = ref m_multiTimedAnimationPool.Value.Get(entity);

				timedAnimComp.SpritesTime = multiTimedAnimComp.SpritesTime;
				timedAnimComp.SpritesNames = multiTimedAnimComp.SpritesNames;
			}
			foreach (int entity in m_multiTimedAnimationFilter.Value)
			{
				ref MultiTimedAnimationComponent multiTimedAnimComp = ref m_multiTimedAnimationPool.Value.Get(entity);

				if (multiTimedAnimComp.HaveAnimationChanged)
				{
					ref TimedAnimationComponent timedAnimComp = ref m_timedAnimationPool.Value.Get(entity);
					int animationIndex = multiTimedAnimComp.Animations[multiTimedAnimComp.CurrentAnimation];

					timedAnimComp.SpritesNumber = multiTimedAnimComp.AnimationsSpritesNumbers[animationIndex];
					timedAnimComp.AnimationCurrentTime = 0f;
					timedAnimComp.CurrentSprite = multiTimedAnimComp.AnimationsStartIndex[animationIndex];
					timedAnimComp.AnimationStartIndex = timedAnimComp.CurrentSprite;
					timedAnimComp.AnimationLastIndex = timedAnimComp.AnimationStartIndex + timedAnimComp.SpritesNumber - 1;

					multiTimedAnimComp.HaveAnimationChanged = false;
				}
			}

			foreach (int entity in m_animationFilter.Value)
			{
				ref RendererComponent rendererComp = ref m_rendererPool.Value.Get(entity);
				ref AnimationComponent animationComp = ref m_animationPool.Value.Get(entity);
				animationComp.AnimationCurrentTime += EngineData.DeltaTime;
				animationComp.AnimationCurrentTime = animationComp.AnimationCurrentTime > animationComp.AnimationTime ? 0 : animationComp.AnimationCurrentTime;
				rendererComp.Sprite = SpriteUtility.GetSprite(animationComp.SpritesNames[(int)(animationComp.AnimationCurrentTime * animationComp.SpritesNumber / animationComp.AnimationTime) + animationComp.AnimationStartIndex]);
			}
			foreach (int entity in m_timedAnimationFilter.Value)
			{
				ref RendererComponent rendererComp = ref m_rendererPool.Value.Get(entity);
				ref TimedAnimationComponent timedAnimComp = ref m_timedAnimationPool.Value.Get(entity);
				timedAnimComp.AnimationCurrentTime += EngineData.DeltaTime;
				if (timedAnimComp.AnimationCurrentTime > timedAnimComp.SpritesTime[timedAnimComp.CurrentSprite])
				{
					timedAnimComp.CurrentSprite++;
					timedAnimComp.CurrentSprite = timedAnimComp.CurrentSprite > timedAnimComp.AnimationLastIndex ? timedAnimComp.AnimationStartIndex : timedAnimComp.CurrentSprite;
					timedAnimComp.AnimationCurrentTime = 0f;
				}
				rendererComp.Sprite = SpriteUtility.GetSprite(timedAnimComp.SpritesNames[timedAnimComp.CurrentSprite]);
			}
		}

		private EcsFilterInject<Inc<TransformComponent, RendererComponent, AnimationComponent>> m_animationFilter;
		private EcsFilterInject<Inc<TransformComponent, RendererComponent, TimedAnimationComponent>> m_timedAnimationFilter;
		private EcsFilterInject<Inc<TransformComponent, RendererComponent, MultiAnimationComponent>, Exc<AnimationComponent>> m_multiAnimationsNotInitFilter;
		private EcsFilterInject<Inc<TransformComponent, RendererComponent, MultiAnimationComponent, AnimationComponent>> m_multiAnimationFilter;
		private EcsFilterInject<Inc<TransformComponent, RendererComponent, MultiTimedAnimationComponent>, Exc<TimedAnimationComponent>> m_multiTimedAnimationsNotInitFilter;
		private EcsFilterInject<Inc<TransformComponent, RendererComponent, MultiTimedAnimationComponent, TimedAnimationComponent>> m_multiTimedAnimationFilter;

		private EcsPoolInject<RendererComponent> m_rendererPool;
		private EcsPoolInject<AnimationComponent> m_animationPool;
		private EcsPoolInject<TimedAnimationComponent> m_timedAnimationPool;
		private EcsPoolInject<MultiAnimationComponent> m_multiAnimationPool;
		private EcsPoolInject<MultiTimedAnimationComponent> m_multiTimedAnimationPool;
	}
}
