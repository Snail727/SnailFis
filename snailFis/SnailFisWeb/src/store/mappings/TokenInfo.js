import { mapGetters } from 'vuex'
import { mapMutations} from 'vuex'
export default {
    computed: mapGetters({
        store_token_accesstoken:'store_token_accesstoken',
        store_token_refreshtoken:'store_token_refreshtoken',
        store_token_exp:'store_token_exp',
    }),
    methods:mapMutations({
        UpdateToken(state,obj){
            this.$store.commit('updateToken',obj);
        },
    }),
}