using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace TestTask.Helper
{
    public class SkillManager : MonoBehaviour
    {

        public List<string> NameList;

        void PopulateDropdown(Dropdown dropdown, GameObject[] optionsArray)
        {
            List<string> options = new List<string>();
            foreach (var option in optionsArray)
            {
                options.Add(option.name); // Or whatever you want for a label
            }
            dropdown.ClearOptions();
            dropdown.AddOptions(options);
        }
    }
}