import { mapMutations} from 'vuex'
export default {
    methods:mapMutations({
        UpdateToken(state,obj){
            this.$store.commit('updateToken',obj);//更新token
        },
        ClearToken(){
            this.$store.commit('updateToken',{Accesstoken:"",Refreshtoken:"",Exp:0});//清除token
        }
    }),
}