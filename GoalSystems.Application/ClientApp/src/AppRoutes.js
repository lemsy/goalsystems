import { AddItem } from "./components/AddItem";
import { FetchData } from "./components/FetchData";

const AppRoutes = [
  {
    index: true,
        element: <FetchData />
  },
  {
      path: '/additem',
      element: <AddItem />
  }
];

export default AppRoutes;
