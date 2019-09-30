import createAxios from './../Config/axios'

export default class CampanhaApi {

    list = async () => createAxios.get('/child/all')

    associate = async (childId, associateChild) => {
        return createAxios.put('/child/associate',
            {
                "ChildId": childId,
                "AssociateChild": associateChild
            }
        );
    }
}