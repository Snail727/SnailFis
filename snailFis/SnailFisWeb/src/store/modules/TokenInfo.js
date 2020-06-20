export default {
    state: {
        accesstoken: "",
        refreshtoken: "",
        exp:0,
    },
    getters: {
        store_token_accesstoken:state=>{
            return state.accesstoken
        },
        store_token_refreshtoken(state) {
            return state.refreshtoken
        },
        store_token_exp(state) {
            return state.exp
        },
    },
    mutations:{
        updateToken(state,obj){
            state.accesstoken=obj.Accesstoken;
            state.refreshtoken=obj.Refreshtoken;
            state.exp=obj.Exp;
        },
    },
};