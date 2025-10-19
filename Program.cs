using GenericBinaryTree;


GenericBinaryNode<int> leftChild = new GenericBinaryNode<int>(3);
GenericBinaryNode<int> rightChild = new GenericBinaryNode<int>(8);
GenericBinaryNode<int> root = new GenericBinaryNode<int>(5);

root.LeftChild = leftChild;
root.RightChild = rightChild;
GenericBinaryTree<int> tree = new GenericBinaryTree<int>(root);
tree.DisplayTree();


  