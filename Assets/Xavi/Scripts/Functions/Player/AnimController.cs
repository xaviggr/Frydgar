using UnityEngine;

namespace StarterAssets
{
    public class AnimController : MonoBehaviour
    {
        private int _animIDDie;
        private int _animIDKick;
        private int _animIDAttack;
        private int _animIDHurt;
        private int _animIDShield;
        private int _animIDArmed;

        private Animator _animator;
        private GunController _guncontroller;

        private bool attacking;


        private static AnimController _instance;
        public static AnimController Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<AnimController>();
                }
                return _instance;
            }
        }

        public bool Attacking { get => attacking; set => attacking = value; }

        private void Awake()
        {
            _animator = this.GetComponent<Animator>();
            _guncontroller = this.GetComponent<GunController>();
        }

        private void Start()
        {
            AssignAnimationIDs();
        }

        private void AssignAnimationIDs()
        {
            _animIDHurt = Animator.StringToHash("Hurt");
            _animIDKick = Animator.StringToHash("Kick");
            _animIDAttack = Animator.StringToHash("Attack");
            _animIDDie = Animator.StringToHash("Die");
            _animIDShield = Animator.StringToHash("Shield");
            _animIDArmed = Animator.StringToHash("IsArmed");
        }

        public void AnimShield(bool value)
        {
            if (_guncontroller.isarmed) _animator.SetBool(_animIDShield, value);
        }

        public void AnimArmed()
        {
            _guncontroller.isarmed = !_guncontroller.isarmed;
            _guncontroller.UpdateGameObjectOnPlayer(_guncontroller.isarmed);
            _animator.SetBool(_animIDArmed, _guncontroller.isarmed);
        }

        public void AnimPlayHurt()
        {
            _animator.SetTrigger(_animIDHurt);
        }

        public void AnimPlayAttack()
        {
            if ((!Attacking) && (_guncontroller.isarmed)) _animator.SetTrigger(_animIDAttack);
        }

        public void AnimPlayKick()
        {
            if ((!Attacking) && (_guncontroller.isarmed)) _animator.SetTrigger(_animIDKick);
        }

        public void AnimPlayDie()
        {
            if (!StatsPlayerController.Instance.player_stats.Dead) _animator.SetTrigger(_animIDDie);
        }

        private void OnEnable()
        {
            StatsPlayerController.Instance.player_stats.TriggerHurt += AnimPlayHurt;
            StarterAssetsInputs.Instance.Shield += AnimShield;
            StarterAssetsInputs.Instance.Armed += AnimArmed;
        }

        private void OnDisable()
        {
            StatsPlayerController.Instance.player_stats.TriggerHurt -= AnimPlayHurt;
            StarterAssetsInputs.Instance.Shield -= AnimShield;
            StarterAssetsInputs.Instance.Armed -= AnimArmed;
        }
    }
}