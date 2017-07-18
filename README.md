# NSS Bag-O-Loot Exercise

## User Objectives
1. Register a child
2. Assign toy to a child
3. Revoke toy from child
4. Review child's toy list
5. Child toy delivery complete
6. Yuletime Delivery Report

## Testing Requirements
1. Items can be added to bag, and assigned to a child.
1. Items can be removed from bag, per child. Removing `Ball`, for example, from the bag should not be allowed. A child's name must be specified.
1. Must be able to list all children who are getting a toy.
1. Must be able to list all toys for a given child's name.
1. Must be able to set the *delivered* property of a child, which defaults to `false` to `true`.