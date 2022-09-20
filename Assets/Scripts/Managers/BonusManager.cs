using System.Collections;
using System.Collections.Generic;

namespace RollerBall.Interactable
{
    public class BonusManager : InteractableManager, IEnumerable
    {
        private List<InteractableObject> positiveBonuses = new List<InteractableObject>();
        private List<InteractableObject> negativeBonuses = new List<InteractableObject>();

        public InteractableObject this[int index]
        {
            get
            {
                if (index < positiveBonuses.Count)
                {
                    return positiveBonuses[index];
                }

                return negativeBonuses[index];
            }
        }

        private void SortBonuses(BonusObject bonusInstance)
        {
            if (bonusInstance.IsPositive)
            {
                bonusInstance.AddToList(positiveBonuses);
            }
            else
            {
                bonusInstance.AddToList(negativeBonuses);
            }
        }
        public override InteractableObject InstantiateObject()
        {
            BonusObject objectInstance = (BonusObject)base.InstantiateObject();
            SortBonuses(objectInstance);
            return objectInstance;
        }

        public IEnumerator GetEnumerator()
        {
            int i = 0;
            while (i < positiveBonuses.Count)
            {
                yield return positiveBonuses[i];
                i += 1;
            }
            i = 0;
            while (i < negativeBonuses.Count)
            {
                yield return negativeBonuses[i];
                i += 1;
            }
        }
    }
}

