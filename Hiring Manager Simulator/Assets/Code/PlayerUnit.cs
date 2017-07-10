public class PlayerUnit : Unit
{
    public GunController gun;

    protected override void Kill()
    {
        Destroy(gameObject);
    }
}
