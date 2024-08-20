public class ZombieFactory : MonsterFactory
{
    public override Monster Create()
    {
        return Instantiate(new Zombie());
    }
}
