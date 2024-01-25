import React, { useState, useEffect } from 'react';

function Index() {
    const [veiculos, setVeiculos] = useState([]);
    //to do Criar função de buscar veiculos

    async function getVeiculos() {
        try {
            const response = await fetch('https://localhost:7053/api/Veiculo/VeiculosDisponiveis');
            const data = await response.json();
            console.log(data);
            setVeiculos(data);
        }
        catch (error) {
            console.erro("Erro ao obter veiculos", error);
        }
    }

    useEffect(() => {
        getVeiculos();
    }, []);
    return (

        <div className="veiculos-container">
            {
                veiculos.map(veiculo => (
                    <div key={veiculo.id} className="card">
                        
                        <img class="card-img-top" src="{veiculo.imagem}" alt="{`Veiculo ${veiculo.tipoVeiculo}`}"/ >
                            <div class="card-body">
                                <h5 class="card-title">Veiculo</h5>
                                {/*//corrigir*/}
                                <p class="card-text"> Tipo do Veiculo: {veiculo.tipoVeiculo}</p>
                                <p class="card-text"> Estado: {veiculo.estado}</p>
                                <p class="card-text"> Ano: {veiculo.ano}</p>
                                <p class="card-text"> Placa: {veiculo.placa}</p>
                                <a href="#" class="btn btn-primary">Alugar</a>
                        </div>
                    </div>
                ))
            }
        </div>
    );
}

export default Index;