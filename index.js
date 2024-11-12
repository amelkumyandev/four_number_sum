function fourNumberSum(array, targetSum) {
    // Initialize a dictionary to store pairs of numbers and their sums
    const pairSums = {};
    // Array to store the resulting quadruplets
    const quadruplets = [];

    // Traverse through the array from the second element to the end
    for (let i = 1; i < array.length - 1; i++) {
        // Check for pairs in the array to the right of the current element
        for (let j = i + 1; j < array.length; j++) {
            const currentSum = array[i] + array[j];
            const difference = targetSum - currentSum;

            // If the difference is found in the dictionary, form quadruplets
            if (pairSums[difference]) {
                for (const pair of pairSums[difference]) {
                    quadruplets.push([...pair, array[i], array[j]]);
                }
            }
        }

        // Add pairs from the left side of the current element to the dictionary
        for (let k = 0; k < i; k++) {
            const currentSum = array[i] + array[k];
            if (!pairSums[currentSum]) {
                pairSums[currentSum] = [];
            }
            pairSums[currentSum].push([array[k], array[i]]);
        }
    }

    return quadruplets;
}

// Sample usage
const array = [7, 6, 4, -1, 1, 2];
const targetSum = 16;
console.log(fourNumberSum(array, targetSum));
// Output: [ [ 7, 6, 4, -1 ], [ 7, 6, 1, 2 ] ]
