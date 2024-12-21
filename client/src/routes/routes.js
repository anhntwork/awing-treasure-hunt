const routes = [
    {
      path: '/',
      component: HomePage,
      isPrivate: false,
    },
    {
      path: '/dashboard',
      component: DashboardPage,
      isPrivate: true,
    },
  ];
  
  export default routes;
  