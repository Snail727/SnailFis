export default {
    state: {
        count: 1,
    },
    getters: {
        store_test_count(state) {
            return state.count
        },
    },
};