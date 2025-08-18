class Solution(object):
    def twoSum(self, nums, target):
        
        nums_TEMP = {}
        for index, value in enumerate(nums):
            if value not in nums_TEMP:
                nums_TEMP[value] = f'{index}'
            else:
                nums_TEMP[value] += f',{index}'

        nums.sort()
        left = 0
        right = len(nums) - 1

        while left < right:
            current_sum = nums[left] + nums[right]
            if current_sum == target:

                leftValue = nums_TEMP[nums[left]].split(',')
                rightValue = nums_TEMP[nums[right]].split(',')

                if len(leftValue) > 1:
                    return [int(leftValue[0]), int(leftValue[1])]
                elif len(rightValue) > 1:
                    return [int(rightValue[0]), int(rightValue[1])]
                else:
                    return [int(leftValue[0]), int(rightValue[0])]
            elif current_sum < target:
                left += 1
            else:
                right -= 1

        return []

if __name__ == "__main__":
    nums = [2,7,11,15]
    target = 9
    solution = Solution()
    result = solution.twoSum(nums, target)
    print(f"Input: nums = {nums}, target = {target}")
    print(f"Output: {result}")