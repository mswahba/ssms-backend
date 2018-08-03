import user from "./users/UserStore";
import shared from "./shared/SharedStore";
import eduAssets from "./basic/EduAssetsStore";

const CentralStore = {
  user,
  shared,
  eduAssets
};

export const getState = () => {
  return Object.entries(CentralStore).reduce((acc, item) => {
    acc[item[0]] = item[1]['state'];
    return acc;
  }, {});
};

export const getActions = (AppStore) => {
  return Object.entries(CentralStore).reduce((acc, item) => {
    const { methods } = item[1];
    const methodsKeyVal = Object.entries(methods);
    for (let i = 0; i < methodsKeyVal.length; i++)
      acc[methodsKeyVal[i][0]] = methodsKeyVal[i][1].bind(AppStore);
    return acc;
  }, {});
};