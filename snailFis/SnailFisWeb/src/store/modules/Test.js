export default {
    state: {
        count: 1,
    },
    getters: {
        store_Test_Count(state) {
            return state.count
        },
    },
};