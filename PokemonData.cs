using UnityEngine;

public class PokemonData : MonoBehaviour
{
    [SerializeField] private string namePokemon1 = "Bulbizard";
    [SerializeField] private int maxPvPokemon1 = 50;
    private float currentPv1;
    [SerializeField] private int attackPokemon1 = 10;
    [SerializeField] private int defensePokemon1 = 10;
    private int statPokemon1;
    [SerializeField] private float weightPokemon1 = 6.9f;
    [SerializeField] private typePokemon pokemonType1 = typePokemon.Plant;
    [SerializeField] private typePokemon[] weakPokemon1 = { typePokemon.Fire, typePokemon.Ice, typePokemon.Psy, typePokemon.Flight };
    [SerializeField] private typePokemon[] resistancePokemon1 = { typePokemon.Water, typePokemon.Plant, typePokemon.Electrik, typePokemon.Fighting, typePokemon.Fairy };

    [SerializeField] private string namePokemon2 = "Charmander";
    [SerializeField] private int maxPvPokemon2 = 50;
    private float currentPv2;
    [SerializeField] private int attackPokemon2 = 8;
    [SerializeField] private int defensePokemon2 = 9;
    private int statPokemon2;
    [SerializeField] private float weightPokemon2 = 8.5f;
    [SerializeField] private typePokemon pokemonType2 = typePokemon.Fire;
    [SerializeField] private typePokemon[] weakPokemon2 = { typePokemon.Water, typePokemon.Ground, typePokemon.Rock };
    [SerializeField] private typePokemon[] resistancePokemon2 = { typePokemon.Fire, typePokemon.Plant, typePokemon.Ice, typePokemon.Insect, typePokemon.Steel, typePokemon.Fairy };

    enum typePokemon
    {
        Darkness,
        Dragon,
        Electrik,
        Fairy,
        Fighting,
        Fire,
        Flight,
        Ground,
        Ice,
        Insect,
        Normal,
        Plant,
        Poison,
        Psy,
        Rock,
        Spectrum,
        Steel,
        Water
    }


    // fonctions qui permettent d'écrire des infos sur les pokemons
    void DisplayName(string pokemonName)
    {
        Debug.Log("Le nom du pokemon c'est " + pokemonName);
    }
    void DisplayPv(int pvPokemon)
    {
        Debug.Log("Le nombre de pv du pokemon est " + pvPokemon);
    }
    void DisplayCurrentHp(float actualHp)
    {
        Debug.Log("Il a actuellement " + actualHp + " pv");
    }
    void DisplayAttack(int attackPokemon)
    {
        Debug.Log("Son attaque est forte, elle inflige " + attackPokemon + " de dégats");
    }
    void DisplayDefense(int defensePokemon)
    {
        Debug.Log("Sa défense est forte, elle le protège de " + defensePokemon + " de dégats");
    }
    void DisplayStat(int statPokemon)
    {
        Debug.Log("Ses statistiques sont hallucinante, il a " + statPokemon + " points de statistique");
    }
    void DisplayWeight(float weightPokemon)
    {
        Debug.Log("Ce pokemon est lourd, il pèse " + weightPokemon + "kg");
    }
    void DisplayWeak(typePokemon[] weakPokemon)
    {
        for (int i = 0; i < weakPokemon.Length; i++)
        {
            Debug.Log("Sa faiblesse numéro " + (i + 1) + " est : " + weakPokemon[i]);
        }
        
    }
    void DisplayResistance(typePokemon[] resistancePokemon)
    {
        for (int i = 0; i < resistancePokemon.Length; i++)
        {
            Debug.Log("Sa resistance numéro " + (i + 1) + " est : " + resistancePokemon[i]);
        }
    }
    void DisplayType(typePokemon Pokemontype)
    {
        Debug.Log("Ce pokemon est de type : " + Pokemontype);
    }

    //initie les pv actuel du pokemon grâce au pv max et initie les stats du pokemon grâce à l'attaque, à la défense et aux pv max
    private float InitCurentLife(int maxPvPokemon, float currentPv)
    {
        currentPv += maxPvPokemon;
        return currentPv;
    }
    private int InitStatsPoints(int attackPokemon, int defensePokemon, int maxPvPokemon, int statPokemon)
    {
        statPokemon += attackPokemon + defensePokemon + maxPvPokemon;
        return statPokemon;
    }

    //vérifie si les pv actuel du pokemon sont strictement supérieur à 0 et renvoie true ou false
    private bool IsPlayerAlive(float currentPv)
    {
        return currentPv > 0;
    }
    //récupère l'attaque du pokemon
    private int GetAttackDamage(float attackDamage)
    {
        return (int)attackDamage;
    }

    //fonction d'attaque qui (en fonction des faiblesse et resistance des pokemons) inflige des dégats au pokemon attaqué
    private void TakeDamage(string namePokemon, float pointsAttack, ref float currentPv, typePokemon typeEnnemy, typePokemon[] weakPokemon, typePokemon[] resistancePokemon)
    {
        float attack = GetAttackDamage(pointsAttack);
        for (int i = 0; i < weakPokemon.Length; i++)
        {
            // si l'adversaire est d'un type qui est dans le tableau des faiblesse ses dégats se voient être augmentés
            if (typeEnnemy == weakPokemon[i])
            {
                currentPv -= attack * 2;
                Debug.Log(namePokemon + " n'est pas très resistant contre le type " + typeEnnemy + " et prend " + attack + " de dégats");
                if (currentPv <= 0)
                {
                    Debug.Log("Il reste 0pv et " + namePokemon + " est mort");
                    return;
                }
                else
                {
                    Debug.Log("Il reste " + currentPv + " et " + namePokemon + " va attaquer");
                    return;
                }
                
            }
            // si l'adversaire est d'un type qui est dans le tableau des résistances ses dégats se voient être diminués
            else
            {
                for (int j = 0; j < resistancePokemon.Length; j++)
                {
                    if (typeEnnemy == resistancePokemon[j])
                    {
                        currentPv -= attack * 0.5f;
                        Debug.Log(namePokemon + " est très resistant contre le type " + typeEnnemy + " et prend " + attack + " de dégats");
                        if (currentPv <= 0)
                        {
                            Debug.Log("Il reste 0pv et " + namePokemon + " est mort");
                            return;
                        }
                        else
                        {
                            Debug.Log("Il reste " + currentPv + " et " + namePokemon + " va attaquer");
                            return;
                        }
                    }
                    
                }
                

            }
            // si le type de l'adverssaire n'est ni dans weakPokemon ni dans resistancePokemon l'attaque de l'ennemie n'est pas changée
            currentPv -= attack;
            Debug.Log(namePokemon + " prend " + attack + " de dégats");
            if (currentPv <= 0)
            {
                Debug.Log("Il reste 0pv et " + namePokemon + " est mort");
                return;
            }
            else
            {
                Debug.Log("Il reste " + currentPv + " et " + namePokemon + " va attaquer");
                return;
            }
        }
        
        
    }

    //on utilise les deux fonction d'initialisation avant le start
    private void Awake()
    {
        currentPv1 = InitCurentLife(maxPvPokemon1, currentPv1);
        currentPv2 = InitCurentLife(maxPvPokemon2, currentPv2);
        statPokemon1 = InitStatsPoints(attackPokemon1, defensePokemon1, maxPvPokemon1, statPokemon1);
        statPokemon2 = InitStatsPoints(attackPokemon2, defensePokemon2, maxPvPokemon2, statPokemon2);
    }

    // Start is called before the first frame update
    void Start()
    {
        DisplayName(namePokemon1);
        DisplayPv(maxPvPokemon1);
        DisplayCurrentHp(currentPv1);
        DisplayAttack(attackPokemon1);
        DisplayDefense(defensePokemon1);
        DisplayStat(statPokemon1);
        DisplayWeight(weightPokemon1);
        DisplayWeak(weakPokemon1);
        DisplayResistance(resistancePokemon1);
        DisplayType(pokemonType1);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsPlayerAlive(currentPv1) && IsPlayerAlive(currentPv2))
        {
            TakeDamage(namePokemon2, attackPokemon1, ref currentPv2, pokemonType1, weakPokemon2, resistancePokemon2);
            if (IsPlayerAlive(currentPv2) && IsPlayerAlive(currentPv1))
            {
                TakeDamage(namePokemon1, attackPokemon2, ref currentPv1, pokemonType2, weakPokemon1, resistancePokemon1);
            }
            
        }
        

    }


}
