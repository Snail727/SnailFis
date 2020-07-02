import Vue from 'vue'
import Router from 'vue-router'
import HomePage from '@/snailFis/HomePage'
import First from '@/snailFis/First'
import Login from '@/snailFis/Login'
import Sport from '@/snailFis/sport/Sport'
import Menu from '@/components/Menu'
import HelloWorld from '@/components/HelloWorld'
import BtContent from '@/study/baseData/BtContent'
import AssContent from '@/study/component/AssContent'
import RouterContent from '@/study/routers/RouterContent'
import RouterChild from '@/study/routers/RouterChild'
import VuexContent from '@/study/vuexs/VuexContent'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'HomePage',
      component: HomePage,
      children:[
        {path:'',component:First},
        {path:'Sport',component:Sport},
      ]
    },
    {
      path: '/Login',
      name: 'Login',
      component: Login
    },
    // {
    //   path: '/BtContent',
    //   name: 'BtContent',
    //   component: BtContent
    // },
    // {
    //   path: '/AssContent',
    //   name: 'AssContent',
    //   component: AssContent
    // },
    // {
    //   path: '/RouterContent',
    //   name: 'RouterContent',
    //   component: RouterContent,
    //   children:[
    //     {path:'',component:First},
    //     {path:'RouterChild',component:RouterChild},
    //   ]
    // },
    // {
    //   path: '/VuexContent',
    //   name: 'VuexContent',
    //   component: VuexContent
    // },
  ]
})
