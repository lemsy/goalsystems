import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom'


import { baseUrl } from '../apiConfig'

export function AddItem() {

    const [name, setName] = useState('')
    const [type, setType] = useState('')
    const [expirationDate, setExpirationDate] = useState('')

    const navigate = useNavigate()

    const handleSubmit = async (e) =>{

        e.preventDefault()

        const response = await fetch(`${baseUrl}/create`, {

            method: 'POST',
            body: JSON.stringify({
                name: name,
                type: type,
                expirationDate: expirationDate
            }),
            headers: {
                'Content-Type': 'application/json'
            },
            
        })

        if (response.ok) navigate('/')
        else alert(response.text)

        
    }

    return <div>
        <h1>Add Item</h1>



        <form onSubmit={handleSubmit}>
            <label>
                Name:<br />
                <input type="text" required value={name} onChange={(e) => setName(e.target.value)} />
            </label><br />
            <label>
                Type:<br />
                <input type="text" required value={type} onChange={(e) => setType(e.target.value)} />
            </label><br />
            <label>
                Expiration date:<br />
                <input type="date" required value={expirationDate} onChange={(e) => setExpirationDate(e.target.value)} />
            </label><br /><br />
            <input type="submit" className="btn btn-primary" value="Add" />
        </form>
    </div>
}







//export class AddItem extends Component {
//    static displayName = AddItem.name;


//  constructor(props) {
//      super(props);
//      this.state = { name: '', type: '', expirationDate: '' };

//      this.handleChangeName = this.handleChangeName.bind(this);
//      this.handleChangeType = this.handleChangeType.bind(this);
//      this.handleChangeExpirationDate = this.handleChangeExpirationDate.bind(this);
//      this.handleSubmit = this.handleSubmit.bind(this);
//  }

//    handleChangeName(e) { this.setState({ name: e.target.value }) }
//    handleChangeType(e) { this.setState({ type: e.target.value }) }
//    handleChangeExpirationDate(e) { this.setState({ expirationDate: e.target.value }) }


    

//  render() {
//    return (
      
//    );
//  }
//}