export default {
    state: {
        accesstoken: "",
        refreshtoken: "",
        exp:0,
    },
    mutations:{
        updateToken(state,obj){
            state.accesstoken=obj.Accesstoken;
            state.refreshtoken=obj.Refreshtoken;
            state.exp=obj.Exp;
        },
        updateAccesstoken(state,obj){
            state.accesstoken=obj.Accesstoken;
            state.exp=obj.Exp;
        }
    },
};