using UnityEngine;

public class Tag : MonoBehaviour
{
    // public string newTag = "NewTag"; // Set the desired new tag in the Unity Editor
    public bool IsChangable;
    void Start()
    {
        // Call the recursive function to change tags for all children
       // ChangeTagsRecursively();
    }
    private void Update()
    {
        print(IsChangable);
    }

    public void ChangeTagsRecursively()
    {
        IsChangable = true;
        //this.gameObject.tag = "GlockGun";
    }
    public void print()
    {
        print("kjjh");
    }
}
